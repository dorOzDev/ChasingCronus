using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

/// <summary>
/// This holds the data for the amount of in game cards.
/// Any type of special card will have it's amount adjusted in here.
/// </summary>
namespace Assets.Scripts.Core
{
    [CreateAssetMenu(fileName = "Game data instance", menuName = "ScriptableObjects/Create game data instance")]
    class GameData : ScriptableObject
    {
        [Tooltip("The number of generated cards")]
        [SerializeField] 
        [Range(10, 30)]
        private int numberOfCards = 10;
        public int NumberOfCards => numberOfCards;

        [Tooltip("The number of generated zeus cards")]
        [SerializeField]
        [Range(0, 2)]
        private int numberOfZeusCards = 1;
        public int NumberOfZeusCards => numberOfZeusCards;

        [Tooltip("The numer of generated cronus cards")]
        [SerializeField]
        [Range(1, 2)]
        private int numberOfCronusCards = 1;
        public int NumberOfCronusCards => numberOfCronusCards;
    }
}
