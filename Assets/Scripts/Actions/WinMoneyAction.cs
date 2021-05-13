using Assets.Scripts.ActionsHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Actions
{
    class WinMoneyAction : BaseAction
    {
        [SerializeField]
        private int moneyToWin = 0;

        public int MoneyToWin => moneyToWin;
        public override void DoAction()
        {
            moneyActionHandler.AddCurrency(moneyToWin);
        }
    }
}
