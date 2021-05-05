using Assets.Scripts.Animations;
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
        [NonSerialized]
        public CardData card;

        [NonSerialized]
        public int cardNumber;

        private FlipCardAnimation flipCard;

        private void Awake()
        {
            flipCard = GetComponent<FlipCardAnimation>();
        }
        public void OnCardClicked()
        {
            SetFrontSprite();
        }

        private void SetFrontSprite()
        {
            flipCard.FlipCard();
        }
    }
}
