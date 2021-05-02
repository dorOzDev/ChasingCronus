using System;
using System.Collections;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Animations
{
    class FlipCardAnimation : MonoBehaviour
    {
        [SerializeField] private Sprite backCard;
        [SerializeField] private Sprite defaultFront;
        [SerializeField] private float animationDuration;

        private Sprite frontCard;
        
        private Image cardImage;

        private bool cardBackIsActive;

        private Vector3 nineteenDegrees = new Vector3(0, 90, 0);

        private bool isFlipping;

        private void Awake()
        {
            cardImage = GetComponent<Image>();
        }

        private void Start()
        {
            cardBackIsActive = true;
            isFlipping = false;
        }

        public void FlipCard()
        {
            FlipCard(defaultFront);
        }

        public void FlipCard(Sprite frontCard)
        {
            this.frontCard = frontCard;
            if (!isFlipping)
                StartCoroutine(FullyFlipCard());
        }

        private IEnumerator FullyFlipCard()
        {
            ChangeFlippingState(true);
            isFlipping = true;
            yield return RotateCardNinetyDegrees();
            MiddleFlipChange();
            yield return RotateCardNinetyDegrees();
            ChangeFlippingState(false);

        }

        private void MiddleFlipChange()
        {
            ChangeSprite();
            ChangeCardState();
        }

        private void ChangeFlippingState(bool state)
        {
            isFlipping = state;
        }

        private void ChangeCardState()
        {
            cardBackIsActive = !cardBackIsActive;
        }

        private void ChangeSprite()
        {
            cardImage.sprite = backCard;

            if (cardBackIsActive) cardImage.sprite = frontCard;
        }

        IEnumerator RotateCardNinetyDegrees()
        {
            Quaternion startRotation = transform.rotation;
            Quaternion endRotation = Quaternion.Euler(nineteenDegrees) * startRotation;

            float timeElapsed = 0f;

            while (timeElapsed <= animationDuration)
            {
                transform.rotation = Quaternion.Lerp(startRotation, endRotation, timeElapsed / animationDuration);
                timeElapsed += Time.deltaTime;
                yield return null;
            }
        }
    }
}
