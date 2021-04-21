using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChasingCronus.Core
{
    public class GameManager : ScriptableObject
    {

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
