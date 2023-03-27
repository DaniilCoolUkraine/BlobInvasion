using BlobInvasion.Player;
using UnityEngine;

namespace BlobInvasion.Shop
{
    [CreateAssetMenu(fileName = "NewShopService", menuName = "ScriptableObjects/ShopService", order = 0)]
    public class ShopServiceSO : ScriptableObject
    {
        [SerializeField] private ScriptableObjectInt _coins;
        
        [SerializeField] private PlayerSettingsSO playerSettingsSo;
        
        [SerializeField] private WeaponShopEntitySO[] _weapons;
        public WeaponShopEntitySO[] Weapons => _weapons;

        public bool TryBuyWeapon(WeaponShopEntitySO weapon)
        {
            bool isBuied = false;

            if (weapon.IsBuied)
            {
                isBuied = true;
                playerSettingsSo.SetWeapon(weapon.Weapon);
            }
            else if (_coins.Value.Value >= weapon.Price)
            {
                _coins.ChangeValue(_coins.Value.Value - weapon.Price, true);
                
                isBuied = true;
                playerSettingsSo.SetWeapon(weapon.Weapon);
            }
            
            return isBuied;
        }
    }
}