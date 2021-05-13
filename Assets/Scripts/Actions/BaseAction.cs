using Assets.Scripts.ActionsHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Actions
{
    public abstract class BaseAction : MonoBehaviour
    {
        protected MoneyActionHandler moneyActionHandler;

        private void Awake()
        {
            moneyActionHandler = FindObjectOfType<MoneyActionHandler>();
        }

        public abstract void DoAction();
    }
}
