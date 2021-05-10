using Assets.Scripts.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Actions
{
    class ActionHandler : MonoBehaviour
    {
        private void OnEnable()
        {
            CardHolder.OnActionSelectedEvent += PerformAction;
        }

        private void OnDisable()
        {
            CardHolder.OnActionSelectedEvent += PerformAction;
        }

        private void PerformAction(BaseAction action)
        {
            action.DoAction();
        }

    }
}
