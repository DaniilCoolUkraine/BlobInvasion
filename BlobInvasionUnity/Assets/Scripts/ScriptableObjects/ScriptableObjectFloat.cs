using System;
using UnityEngine;

namespace BlobInvasion
{
    [CreateAssetMenu (fileName = "ScriptableObjectFloat", menuName = "ScriptableObjects/ScriptableObjectFloat")]
    public class ScriptableObjectFloat : ScriptableObject
    {
        public event Action<float> OnValueChanged;

        [SerializeField] private ValueFloat _value;
        public ValueFloat Value=>_value;

        [SerializeField] private ValueFloat _minValue;
        public ValueFloat MinValue =>_minValue;

        [SerializeField] private ValueFloat _maxValue;
        public ValueFloat MaxValue =>_maxValue;

        public void RestoreAllValues(bool isSendEvent = false)
        {
            float restoredValue = _value.RestoreValue();
            float restoredMinValue = _minValue.RestoreValue();
            float restoredMaxValue = _maxValue.RestoreValue();

            ChangeValue(_value, restoredValue, isSendEvent);
            ChangeValue(_minValue, restoredMinValue, isSendEvent);
            ChangeValue(_maxValue, restoredMaxValue, isSendEvent);
        }

        public void ChangeValue(float newValue, bool isSendEvent = false)
        {
            float clampedValue = Mathf.Clamp(newValue, _minValue.Value, _maxValue.Value);

            ChangeValue(_value, clampedValue, isSendEvent);
        }

        public void ChangeMinValue(float newMinValue, bool isSendEvent = false)
        {
            ChangeValue(_minValue, newMinValue, isSendEvent);
        }

        public void ChangeMaxValue(float newMaxValue, bool isSendEvent = false)
        {
            ChangeValue(_maxValue, newMaxValue, isSendEvent);
        }

        private void ChangeValue(ValueFloat _value, float newValue, bool isSendEvent = false)
        {
            _value.ChangeValue(newValue);

            SendValueChangeEvent(newValue, isSendEvent);
        }

        private void SendValueChangeEvent(float value, bool isSendEvent)
        {
            if (isSendEvent)
            {
                OnValueChanged?.Invoke(value);
            }
        }
    }
}
