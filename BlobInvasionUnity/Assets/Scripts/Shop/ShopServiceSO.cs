using System;
using BlobInvasion.ScriptableObjects;
using BlobInvasion.Settings;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BlobInvasion.Shop
{
    [CreateAssetMenu(fileName = "NewShopService", menuName = "ScriptableObjects/ShopService", order = 0)]
    public class ShopServiceSO : ScriptableObject
    {
        [SerializeField] private ScriptableObjectInt _coins;
        
        [SerializeField] private PlayerSettingsSO _playerSettingsSO;
        [SerializeField] private LevelSettingsSO _levelSettingsSO;
        
        [SerializeField] private WeaponShopEntitySO[] _weapons;
        public WeaponShopEntitySO[] Weapons => _weapons;

        [SerializeField] private LevelShopEntitySO[] _levels;
        public LevelShopEntitySO[] Levels => _levels;

        public bool TryBuyEntity(ShopEntitySO shopEntity)
        {
            bool isBuied = false;
            
            if (shopEntity is WeaponShopEntitySO)
            {
                isBuied = TryBuyWeapon((WeaponShopEntitySO) shopEntity);
            }
            else if (shopEntity is LevelShopEntitySO)
            {
                isBuied = TryBuyLevel((LevelShopEntitySO) shopEntity);
            }

            return isBuied;
        }
        
        private bool TryBuyEntity(ShopEntitySO shopEntitySO, Action OnBied)
        {
            bool isBuied = false;
            
            if (shopEntitySO.IsBuied)
            {
                isBuied = true;
                OnBied?.Invoke();
            }
            else if (_coins.Value.Value >= shopEntitySO.Price)
            {
                _coins.ChangeValue(_coins.Value.Value - shopEntitySO.Price, true);
                
                isBuied = true;
                OnBied?.Invoke();
            }
            
            return isBuied;
        }
        
        private bool TryBuyWeapon(WeaponShopEntitySO weapon)
        {
            return TryBuyEntity(weapon, () => _playerSettingsSO.SetWeapon(weapon.Weapon));
        }
        
        private bool TryBuyLevel(LevelShopEntitySO level)
        {
            return TryBuyEntity(level, () =>
            {
                _levelSettingsSO.SetScene(level.SceneName);
                SceneManager.LoadScene(level.SceneName);
            });
        }
    }
}