using Assets.Scripts.Core;
using Assets.Scripts.GameData;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.ActionsHandlers
{
    public class MoneyActionHandler : MonoBehaviour
    {
        private Text moneyText;

        [SerializeField]
        CurrectCurrencyHolder currencyHolder;

        private LocalGameDataProvider gameDataProvider;
        private void Awake()
        {
            moneyText = GetComponent<Text>();
            gameDataProvider = ScriptableObject.CreateInstance<LocalGameDataProvider>();
        }

        private void Start()
        {

        }

        public void Lose()
        {
            currencyHolder.LostCurrency(gameDataProvider.GetSingleGameCost());
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
