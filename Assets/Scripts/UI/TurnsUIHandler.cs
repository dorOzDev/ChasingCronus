using Assets.Scripts.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    class TurnsUIHandler : MonoBehaviour
    {
        private Text turnsText;

        private void Awake()
        {
            turnsText = GetComponent<Text>();
        }

        private void OnEnable()
        {
            CurrentTurnsHolder.OnNumOfTurnschangedEvent += UpdateUI;
        }

        private void OnDisable()
        {
            CurrentTurnsHolder.OnNumOfTurnschangedEvent -= UpdateUI;
        }

        private void UpdateUI(int currTurns)
        {
            turnsText.text = currTurns + "";
        }
    }
}
