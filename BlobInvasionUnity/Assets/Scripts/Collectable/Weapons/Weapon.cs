using BlobInvasion.Collectable.Weapons.ScriptableObjects;
using BlobInvasion.Damageable;
using UnityEngine;

namespace BlobInvasion.Collectable.Weapons
{
    public abstract class Weapon : MonoBehaviour, IDamager
    {
        [SerializeField] private WeaponDataSO _weaponData;

        public int Damage => _weaponData.Damage;
        public float AttackZoneRadius => _weaponData.AttackRadius;
        public float AttackCooldown => _weaponData.AttackSpeed;

        public abstract void Attack(IDamageable damageable);
    }
}