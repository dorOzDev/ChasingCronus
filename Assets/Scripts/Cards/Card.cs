using Assets.Scripts.Actions;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;



namespace Assets.Scripts.Cards
{
    [CreateAssetMenu(fileName = "Card instnace", menuName = "ScriptableObjects/Create card instance")]
    public class Card : ScriptableObject
    {
        [SerializeField]
        private Sprite frontSprite;

        [SerializeField]
        private IAction action;

        [Tooltip("The amount of generated card of the same type")]
        [SerializeField]
        private int amount;

        [SerializeField]
        private CardType cardType;

        public Sprite FrontSprite => frontSprite;
        public CardType CardType => cardType;

        public int Amount => amount;
    }

    public enum CardType
    {
        NORMAL,
        ZEUS,
        CRONUS
    }
}
