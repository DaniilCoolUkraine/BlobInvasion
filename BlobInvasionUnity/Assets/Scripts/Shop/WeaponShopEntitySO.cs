using BlobInvasion.Collectable.Weapons;
using UnityEngine;

namespace BlobInvasion.Shop
{
    [CreateAssetMenu(fileName = "NewWeaponShopEntity", menuName = "ScriptableObjects/WeaponShopEntity", order = 0)]
    public class WeaponShopEntitySO : ScriptableObject
    {
        [SerializeField] private Sprite _weaponIcon;
        [SerializeField] private int _price;
        [SerializeField] private string _name;
        
        [Space(8)]
        
        [SerializeField] private Weapon _weaponPrefab;

        public Sprite WeaponIcon => _weaponIcon;
        public int Price => _price;
        public string Name => _name;
        
        public Weapon Weapon => _weaponPrefab;
        public bool IsBuied { get; set; }
    }
}