using Assets.Scripts.Cards;
using Assets.Scripts.GameData;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Core
{
    /// <summary>
    /// Generate all the needed empty cards into a list of cards.
    /// </summary>
    public class GameInitializer : MonoBehaviour
    {
        private int cardNumbering;

        [SerializeField]
        private ObjectsPooling pooling;

        [SerializeField]
        private GameObject cardsPanel;

        private IGameDataProvider<CardData> gameDataProvier;

        private void Awake()
        {
            gameDataProvier = ScriptableObject.CreateInstance<LocalGameDataProvider>();
        }

        private void Start()
        {
            InitiateGame();
        }

        public void InitiateGame()
        {
            cardNumbering = 0;
            InstantiateCards();
        }

        private void InstantiateCards()
        {
            int size = gameDataProvier.GetGameCardsCount();
            List<GameObject> emptyCards = pooling.GetGameObjects(size);

            foreach (GameObject card in emptyCards)
            {
                CardHolder cardHolder = card.GetComponent<CardHolder>();

                if(cardHolder == null)
                {
                    gameObject.AddComponent(typeof(CardHolder));
                }

                SetCardProperties(cardHolder);
                ++cardNumbering;
            }
        }

        private void SetCardProperties(CardHolder cardHolder)
        {
            cardHolder.gameObject.transform.SetParent(cardsPanel.transform, false);
            cardHolder.gameObject.SetActive(true);
            cardHolder.cardNumber = cardNumbering;
        }
    }
}
