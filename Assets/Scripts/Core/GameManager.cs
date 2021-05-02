using Assets.Scripts.Cards;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Core
{
    public class GameManager : MonoBehaviour
    {
        private const string defualtCardsPath = "Game/Cards/CardData";
        private void Start()
        {
            // TODO Instantiate cards
            Card[] prefabsArray = Resources.LoadAll<Card>(defualtCardsPath);
            foreach(Card prefab in prefabsArray)
            {

            }
        }

        public int GameGoal { private set; get; }

        public int GameRange = 27;
        private void Awake()
        {
            GenerateNewRandom();
        }

        public void GenerateNewRandom()
        {
            GameGoal = Random.Range(1, GameRange + 1);
        }
    }

}
