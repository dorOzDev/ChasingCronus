using Assets.Scripts.Cards;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static System.Linq.Enumerable;

namespace Assets.Scripts.Core
{
    [RequireComponent(typeof(ObjectsPooling))]
    public class GameManager : MonoBehaviour
    {
        private const string defualtCardsPath = "Game/Cards/CardData";
        private int cardNumbering;

        [SerializeField]
        private ObjectsPooling pooling;
        private void Start()
        {
            cardNumbering = 0;
            InstantiateCards();
        }

        private void InstantiateCards()
        {
            Card[] cardsArray = Resources.LoadAll<Card>(defualtCardsPath);
            foreach (Card card in cardsArray)
            {
                List<GameObject> gameObjects = pooling.GetGameObjects(card.Amount);

                foreach (GameObject gameObject in gameObjects)
                {
                    if (gameObject.GetComponent<CardHolder>() == null)
                    {
                        gameObject.AddComponent(typeof(CardHolder));
                    }
                    SetCardProperties(gameObject.GetComponent<CardHolder>(), card);
                    cardNumbering++;
                }
            }
        }

        private void SetCardProperties(CardHolder cardHolder, Card card)
        {
            cardHolder.card = card;
            cardHolder.cardNumber = cardNumbering;
        }

        public int GameGoal { private set; get; }

        public int GameRange = 27;
        private void Awake()
        {
            GenerateNewRandom();
        }

        public void GenerateNewRandom()
        {
            GameGoal = UnityEngine.Random.Range(1, GameRange + 1);
        }
    }
}
