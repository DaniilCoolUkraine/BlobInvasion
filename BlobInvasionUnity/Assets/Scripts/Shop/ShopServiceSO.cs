using BlobInvasion.Player;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BlobInvasion.Shop
{
    [CreateAssetMenu(fileName = "NewShopService", menuName = "ScriptableObjects/ShopService", order = 0)]
    public class ShopServiceSO : ScriptableObject
    {
        [SerializeField] private ScriptableObjectInt _coins;
        
        [SerializeField] private PlayerSettingsSO _playerSettingsSO;
        
        [SerializeField] private WeaponShopEntitySO[] _weapons;
        public WeaponShopEntitySO[] Weapons => _weapons;

        [SerializeField] private LevelShopEntitySO[] _levels;
        public LevelShopEntitySO[] Levels => _levels;

        public bool TryBuyWeapon(WeaponShopEntitySO weapon)
        {
            bool isBuied = false;

            if (weapon.IsBuied)
            {
                isBuied = true;
                _playerSettingsSO.SetWeapon(weapon.Weapon);
            }
            else if (_coins.Value.Value >= weapon.Price)
            {
                _coins.ChangeValue(_coins.Value.Value - weapon.Price, true);
                
                isBuied = true;
                _playerSettingsSO.SetWeapon(weapon.Weapon);
            }
            
            return isBuied;
        }
        
        public bool TryBuyLevel(LevelShopEntitySO level)
        {
            bool isBuied = false;

            if (level.IsBuied)
            {
                isBuied = true;
                _playerSettingsSO.SetScene(level.Name);
                SceneManager.LoadScene(level.Name);
            }
            else if (_coins.Value.Value >= level.Price)
            {
                _coins.ChangeValue(_coins.Value.Value - level.Price, true);
                
                isBuied = true;
                _playerSettingsSO.SetScene(level.Name);
                SceneManager.LoadScene(level.Name);
            }
            
            return isBuied;
        }
        
    }
}