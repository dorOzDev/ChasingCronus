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

        private GameObject actionsHolder;

        [NonSerialized]
        public int cardNumber;

        private FlipCardAnimation flipCard;

        public delegate void OnActionSelectedDelegate(BaseAction action);
        public static OnActionSelectedDelegate OnActionSelectedEvent;

        public delegate void OnCardClickedDelegate(CardHolder cardHolder);
        public static OnCardClickedDelegate OnCardClickedEvent;

        private BaseAction action;

        private void Awake()
        {
            flipCard = GetComponent<FlipCardAnimation>();
            positioner = GameObject.FindGameObjectWithTag("Positioner").GetComponent<IPositioner>();
            actionsHolder = GameObject.FindGameObjectWithTag("ActionsHolder");
        }
        public void OnCardClicked()
        {
            OnCardClickedEvent?.Invoke(this);
            CardData cardData = positioner.GetCardDataAtPosition(cardNumber);
            if(cardData == null)
            {
                Debug.LogError("Something went wrong getting card data at position: " + cardNumber);
                return;
            }

            FlipCard(cardData.FrontSprite);
            InstantiateAction(cardData.ActionPrefab);
            OnActionSelectedEvent?.Invoke(action);
        }

        private void InstantiateAction(BaseAction actionPrefab)
        {
            action = Instantiate(actionPrefab);

            if(actionsHolder != null)
            {
                action.transform.parent = actionsHolder.transform;
            }
        }

        private void FlipCard(Sprite frontSprite)
        {
            flipCard.FlipCard(frontSprite);
        }
    }
}
