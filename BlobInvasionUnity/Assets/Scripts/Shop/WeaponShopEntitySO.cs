using System;
using BlobInvasion.Collectable.Weapons;
using UnityEngine;

namespace BlobInvasion.Shop
{
    [CreateAssetMenu(fileName = "NewWeaponShopEntity", menuName = "ScriptableObjects/WeaponShopEntity", order = 0)]
    public class WeaponShopEntitySO : ScriptableObject
    {
        public event Action<bool> OnBuied;
        
        [SerializeField] private Sprite _weaponIcon;
        [SerializeField] private int _price;
        [SerializeField] private string _name;
        
        [Space(8)]
        
        [SerializeField] private Weapon _weaponPrefab;

        public Sprite WeaponIcon => _weaponIcon;
        public int Price => _price;
        public string Name => _name;
        
        public Weapon Weapon => _weaponPrefab;

        public bool IsBuied
        {
            get
            {
                return PlayerPrefs.GetInt(_name) == 0 ? false : true;
            }
            set
            {
                if (value)
                {
                    PlayerPrefs.SetInt(_name, 1);
                }
                else
                {
                    PlayerPrefs.SetInt(_name, 0);
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