using BlobInvasion.Damageable;
using BlobInvasion.Items.Weapons.ScriptableObjects;
using UnityEngine;

namespace BlobInvasion.Items.Weapons
{
    public abstract class Weapon : MonoBehaviour, IItem, IDamager
    {
        [SerializeField] private WeaponDataSO _weaponData;
        
        public int Damage => _weaponData.Damage;
        public float AttackZoneRadius => _weaponData.AttackRadius;
        public float AttackCooldown => _weaponData.AttackSpeed;

        public abstract void Attack(IDamageable damageable);
    }
}