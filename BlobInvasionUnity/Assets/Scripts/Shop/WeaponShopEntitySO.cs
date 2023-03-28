using BlobInvasion.Collectable.Weapons;
using UnityEngine;

namespace BlobInvasion.Shop
{
    [CreateAssetMenu(fileName = "NewWeaponShopEntity", menuName = "ScriptableObjects/WeaponShopEntity", order = 0)]
    public class WeaponShopEntitySO : ShopEntitySO
    {
        [Space(8)]
        
        [SerializeField] private Weapon _weaponPrefab;
        public Weapon Weapon => _weaponPrefab;
    }
}