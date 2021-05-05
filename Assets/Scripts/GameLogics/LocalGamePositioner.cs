using Assets.Scripts.Cards;
using Assets.Scripts.GameData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.GameLogics
{
    class LocalGamePositioner : MonoBehaviour, IPositioner
    {
        private Dictionary<int, CardData> mapPositionToCardData = new Dictionary<int, CardData>();

        private IGameDataProvider <CardData> gameDataProvider;

        private void Awake()
        {
            gameDataProvider = ScriptableObject.CreateInstance<LocalGameDataProvider>();
        }

        private void Start()
        {
            InitializeMap();
        }

        private void InitializeMap()
        {
            int cardSize = gameDataProvider.GetGameCardsCount();
            
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
