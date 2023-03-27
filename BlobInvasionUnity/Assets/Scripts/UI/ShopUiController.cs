using System;
using BlobInvasion.Shop;
using UnityEngine;

namespace BlobInvasion.UI
{
    public class ShopUiController : MonoBehaviour
    {
        [SerializeField] private ShopServiceSO _shopServiceSO;
        [SerializeField] private ShopSlotUiController _prefab;

        [SerializeField] private Transform _weaponHolder;

        private void Start()
        {
            Init();
        }

        public void Init()
        {
            ShopSlotUiController temporarySlot;
            
            foreach (var weapon in _shopServiceSO.Weapons)
            {
                temporarySlot = Instantiate(_prefab, _weaponHolder);
                temporarySlot.Init(weapon);

                temporarySlot.OnTryToBuy += TryToBuy;
            }
        }
        
        private void TryToBuy(WeaponShopEntitySO weapon)
        {
            bool isBuied = _shopServiceSO.TryBuyWeapon(weapon);
            weapon.TryToBuy(isBuied);
        }
    }
}