using Assets.Scripts.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

namespace Assets.Scripts.ActionsHandlers
{
    public class MoneyActionHandler : MonoBehaviour
    {
        private Text moneyText;

        [SerializeField]
        CurrectCurrencyHolder currencyHolder;
        private void Awake()
        {
            moneyText = GetComponent<Text>();
        }

        private void Start()
        {
            currencyHolder.ResetCurrency();
            UpdateUI();
        }

        public void Lose()
        {
            currencyHolder.ResetCurrency();
            UpdateUI();
        }

        public void AddCurrency(float amount)
        {
            currencyHolder.AddCurrency(amount);
            UpdateUI();
        }

        private void UpdateUI()
        {
            moneyText.text = currencyHolder.CurrCurency + "";
        }
    }
}
