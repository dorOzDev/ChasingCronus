using Assets.Scripts.Cards;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// This holds the data for the amount of in game cards.
/// </summary>
namespace Assets.Scripts.GameData
{
    class LocalGameDataProvider : ScriptableObject, IGameDataProvider<CardData>
    {
        Dictionary<CardType, CardData> mapTypeToCardData = new Dictionary<CardType, CardData>();
        private const string defualtCardsPath = "Game/Cards/CardData/";

        private void Awake()
        {
            initializeMap();
        }

        private void initializeMap()
        {
            CardData[] cardsArray = Resources.LoadAll<CardData>(defualtCardsPath);
            foreach (CardData card in cardsArray)
            {
                mapTypeToCardData.Add(card.CardType, card);
            }
        }

        public int GetGameCardsCount()
        {
            int sum = 0;

            foreach(KeyValuePair<CardType, CardData> entry in mapTypeToCardData)
            {
                sum += entry.Value.Amount;
            }

            return sum;
        }

        public List<CardData> GetAllCardsList()
        {
            return mapTypeToCardData.Values.ToList();
        }
    }
}
