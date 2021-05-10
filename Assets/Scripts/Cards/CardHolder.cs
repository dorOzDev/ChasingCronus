using Assets.Scripts.Actions;
using Assets.Scripts.Animations;
using Assets.Scripts.GameLogics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Cards
{
    class CardHolder : MonoBehaviour
    {

        [SerializeField]
        private IPositioner positioner;

        [NonSerialized]
        public int cardNumber;

        private FlipCardAnimation flipCard;

        public delegate void OnActionSelectedDelegate(BaseAction action);
        public static OnActionSelectedDelegate OnActionSelectedEvent;

        private void Awake()
        {
            flipCard = GetComponent<FlipCardAnimation>();
            positioner = GameObject.FindGameObjectWithTag("Positioner").GetComponent<IPositioner>();
        }
        public void OnCardClicked()
        {
            CardData cardData = positioner.GetCardDataAtPosition(cardNumber);
            if(cardData == null)
            {
                Debug.LogError("Something went wrong getting card data at position: " + cardNumber);
                return;
            }

            FlipCard(cardData.FrontSprite);
            OnActionSelectedEvent?.Invoke(cardData.Action);
        }

        private void FlipCard(Sprite frontSprite)
        {
            flipCard.FlipCard(frontSprite);
        }
    }
}
