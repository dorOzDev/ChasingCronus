using Assets.Scripts.Actions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;



namespace Assets.Scripts.Cards
{
    [CreateAssetMenu(fileName = "Card instnace", menuName = "ScriptableObjects/Create card instance")]
    public class CardData : ScriptableObject
    {
        [SerializeField]
        private Sprite frontSprite;

        public Sprite FrontSprite => frontSprite;

        [SerializeField]
        private BaseAction action;
        public BaseAction Action => action;

        [Tooltip("The amount of generated card of the same type")]
        [SerializeField]
        private int amount;
        public int Amount => amount;

        [SerializeField]
        private CardType cardType;
        public CardType CardType => cardType;
    }

    public enum CardType
    {
        Empty,
        Normal,
        Zeus,
        Cronous,
        WinMoney
    }
}
