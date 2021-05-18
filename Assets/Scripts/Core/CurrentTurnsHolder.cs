using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Core
{
    [CreateAssetMenu(fileName = "Turns instance", menuName = Utils.NamingConvetionProvider.defaultScriptableObjectsMenuName + "Create turns holder instance")]
    class CurrentTurnsHolder : ScriptableObject
    {
        private int currTurns = 0;
        public int CurrTurns => currTurns;

        public delegate void OnNumOfTurnsChanged(int numOfTurns);
        public static OnNumOfTurnsChanged OnNumOfTurnschangedEvent;

        public void AddTurns(int addTurns)
        {
            currTurns += addTurns;
            OnNumOfTurnschangedEvent?.Invoke(currTurns);
        }

        public void UseTurn()
        {
            currTurns--;
            OnNumOfTurnschangedEvent?.Invoke(currTurns);
        }
    }
}