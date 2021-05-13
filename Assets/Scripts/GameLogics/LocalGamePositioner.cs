using Assets.Scripts.Cards;
using Assets.Scripts.GameData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.GameLogics
{
    class LocalGamePositioner : MonoBehaviour, IPositioner
    {
        private Dictionary<int, CardData> mapPositionToCardData = new Dictionary<int, CardData>();

        private IGameDataProvider <CardData> gameDataProvider;

        private RNGCryptoServiceProvider rnd = new RNGCryptoServiceProvider();

        private void Awake()
        {
            gameDataProvider = ScriptableObject.CreateInstance<LocalGameDataProvider>();
            InitializeMap();
        }

        private void InitializeMap()
        {
            int[] array = Enumerable.Range(0, gameDataProvider.GetGameCardsCount()).ToArray();

            ShuffleArray(array, 2);
            GeneratePositionMap(array);
        }
    // For debug purposes, may safely delete
/*        private void PrintMap()
        {
            foreach(KeyValuePair<int, CardData> entry in mapPositionToCardData)
            {
                print(entry.Key + " to " + entry.Value.CardType);
            }
        }*/

        private void GeneratePositionMap(int[] indexArray)
        {
            List<CardData> cardList = gameDataProvider.GetAllCardsList();
            int index = 0;

            foreach(CardData card in cardList)
            {
                for(int i = 0; i < card.Amount; ++i)
                {
                    mapPositionToCardData.Add(indexArray[index], card);
                    index++;
                }
            }
        }

        private void ShuffleArray(int[] array, int shuffleCounts)
        {
            for(int i = 0; i < shuffleCounts; ++i)
            {
                ShuffleArrayHelper(array);
            }
        }

        private void ShuffleArrayHelper(int[] array)
        {
            for (int i = 0; i < array.Length; ++i)
            {
                int randomIndex = GenerateRandomNumberInRange(array.Length);
                int temp = array[randomIndex];

                array[randomIndex] = array[i];
                array[i] = temp;
            }
        }

        private int GenerateRandomNumberInRange(int range)
        {
            byte[] randomInt = new byte[1];
            rnd.GetBytes(randomInt);
            return Convert.ToInt32(randomInt[0] % range);
        }

        public CardData GetCardDataAtPosition(int position)
        {
            CardData cardData;
            if (!mapPositionToCardData.TryGetValue(position, out cardData))
            {
                Debug.LogError("Position " + position + " is not found.");
            }

            return cardData;
        }
    }
}
