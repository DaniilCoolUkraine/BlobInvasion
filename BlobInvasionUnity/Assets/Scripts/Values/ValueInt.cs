using UnityEngine;

namespace BlobInvasion
{
    [System.Serializable]
    public struct ValueInt
    {
        [SerializeField] private string _name;
        public string Name => _name;

        [SerializeField] private int _value;
        public int Value => _value;

        public int RestoreValue()
        {
            _value = PlayerPrefs.GetInt(Name);
            return _value;
        }

        public void ChangeValue(int newValue)
        {
            _value = newValue;
            PlayerPrefs.SetInt(Name, newValue);
            PlayerPrefs.Save();
        }
    }
}
