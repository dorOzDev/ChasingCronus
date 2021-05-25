using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Core
{
    [CreateAssetMenu(fileName = "Currency instance", menuName = Utils.NamingConvetionProvider.defaultScriptableObjectsMenuName + "Create currency holder instance")]
    class CurrectCurrencyHolder : ScriptableObject
    {
        private float currCurency = 0f;
        public float CurrCurency => currCurency;

        public void AddCurrency(float amount)
        {
            currCurency += amount;
        }

        public void LostCurrency(float amount)
        {
            currCurency = Math.Max(0, currCurency - amount);
        }
    }
}
