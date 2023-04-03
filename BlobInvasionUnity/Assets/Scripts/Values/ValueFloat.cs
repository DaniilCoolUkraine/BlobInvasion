using UnityEngine;

namespace BlobInvasion.Values
{
    [System.Serializable]
    public class ValueFloat
    {
        [SerializeField] private string _name;
        public string Name => _name;

        [SerializeField] private float _value;
        public float Value => _value;

        public float RestoreValue()
        {
            _value = PlayerPrefs.GetFloat(Name);
            return _value;
        }

        public void ChangeValue(float newValue)
        {
            _value = newValue;
            PlayerPrefs.SetFloat(Name, newValue);
            PlayerPrefs.Save();
        }
    }
}
