using System;
using BlobInvasion.Values;
using UnityEngine;

namespace BlobInvasion
{
    [CreateAssetMenu (fileName = "ScriptableObjectInt", menuName = "ScriptableObjects/ScriptableObjectInt")]
    public class ScriptableObjectInt : ScriptableObject
    {
        public event Action<int, int, int> OnValueChanged;

        [SerializeField] private ValueInt _value;
        public ValueInt Value=>_value;

        [SerializeField] private ValueInt _minValue;
        public ValueInt MinValue=>_minValue;

        [SerializeField] private ValueInt _maxValue;
        public ValueInt MaxValue=>_maxValue;

        public void RestoreAllValues(bool isSendEvent = false)
        {
            int restoredValue = _value.RestoreValue();
            int restoredMinValue = _minValue.RestoreValue();
            int restoredMaxValue = _maxValue.RestoreValue();

            ChangeValue(_value, restoredValue, isSendEvent);
            ChangeValue(_minValue, restoredMinValue, isSendEvent);
            ChangeValue(_maxValue, restoredMaxValue, isSendEvent);
        }

        public void ChangeValue(int newValue, bool isSendEvent = false)
        {
            int clampedValue = Mathf.Clamp(newValue, _minValue.Value, _maxValue.Value);

            ChangeValue(_value, clampedValue, isSendEvent);
        }

        public void ChangeMinValue(int newMinValue, bool isSendEvent = false)
        {
            ChangeValue(_minValue, newMinValue, isSendEvent);
        }

        public void ChangeMaxValue(int newMaxValue, bool isSendEvent = false)
        {
            ChangeValue(_maxValue, newMaxValue, isSendEvent);
        }

        private void ChangeValue(ValueInt _value, int newValue, bool isSendEvent = false)
        {
            _value.ChangeValue(newValue);

            SendValueChangeEvent(isSendEvent);
        }

        private void SendValueChangeEvent(bool isSendEvent)
        {
            if (isSendEvent)
            {
                OnValueChanged?.Invoke(_value.Value, _minValue.Value, _maxValue.Value);
            }
        }
    }
}
