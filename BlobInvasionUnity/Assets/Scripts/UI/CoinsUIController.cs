using System;
using TMPro;
using UnityEngine;

namespace BlobInvasion.UI
{
    public class CoinsUIController : MonoBehaviour
    {
        [SerializeField] private ScriptableObjectInt _coinsData;
        [SerializeField] private TextMeshProUGUI _coinsText;

        private void Awake()
        {
            _coinsData.RestoreAllValues();
            UpdateCoinsText(_coinsData.Value.Value, _coinsData.MinValue.Value, _coinsData.MaxValue.Value);
        }

        private void OnEnable()
        {
            _coinsData.OnValueChanged += UpdateCoinsText;
        }

        private void OnDisable()
        {
            _coinsData.OnValueChanged -= UpdateCoinsText;
        }

        private void UpdateCoinsText(int value, int minValue, int maxValue)
        {
            _coinsText.text = value.ToString();
        }
    }
}
