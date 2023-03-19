using BlobInvasion.Collectable.Weapons.ScriptableObjects;
using BlobInvasion.Damageable;
using UnityEngine;

namespace BlobInvasion.Collectable.Weapons
{
    public abstract class Weapon : MonoBehaviour, IDamager
    {
        [SerializeField] protected WeaponDataSO _weaponData;
        
        public float AttackZoneRadius => _weaponData.AttackRadius;

        public abstract void Attack(IDamageable damageable);
    }
}