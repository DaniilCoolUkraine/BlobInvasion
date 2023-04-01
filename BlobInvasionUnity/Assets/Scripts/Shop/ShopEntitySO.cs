using System;
using UnityEngine;

namespace BlobInvasion.Shop
{
    public abstract class ShopEntitySO : ScriptableObject
    {
        public event Action<bool> OnBuied;
        
        [SerializeField] private Sprite _icon;
        [SerializeField] private int _price;
        [SerializeField] private string _displayingName;
        
        public Sprite Icon => _icon;
        public int Price => _price;
        public string Name => _displayingName;
        
        public bool IsBuied
        {
            get
            {
                return PlayerPrefs.GetInt(_displayingName) == 0 ? false : true;
            }
            set
            {
                if (value)
                {
                    PlayerPrefs.SetInt(_displayingName, 1);
                }
                else
                {
                    PlayerPrefs.SetInt(_displayingName, 0);
                }
            }
        }

        public void TryToBuy(bool isBuied)
        {
            if (isBuied)
            {
                IsBuied = true;
                OnBuied?.Invoke(true);
            }
        }
    }
}