using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Actions
{
    class LoseMoneyAction : BaseAction
    {
        public override void DoAction()
        {
            moneyActionHandler.Lose();
        }
    }
}
