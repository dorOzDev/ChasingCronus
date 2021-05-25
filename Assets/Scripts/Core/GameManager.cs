using Assets.Scripts.GameLogics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Core
{
    public class GameManager : MonoBehaviour
    {

        private GameObject positioner;

        private IPositioner iPositioner;

        private void Awake()
        {
            positioner = GameObject.FindGameObjectWithTag("Positioner");
            iPositioner = positioner.GetComponent<IPositioner>();
        }

        private void Start()
        {
            StartNewGame();
        }

        private void StartNewGame()
        {
            
            if(iPositioner == null)
            {
                Debug.LogError("Couldn't find a positioner");
                return;
            }

            iPositioner.ResetCardsPositions();
        }
    }
}
