using BlobInvasion.Collectable.Weapons.ScriptableObjects;
using BlobInvasion.Damageable;
using UnityEngine;

namespace BlobInvasion.Collectable.Weapons
{
    public abstract class Weapon : MonoBehaviour, IDamager
    {
        [SerializeField] protected WeaponDataSO _weaponData;
        
        public float AttackZoneRadius => _weaponData.AttackRadius;

        private void Start()
        {
            _weaponData.AddDamage(-_weaponData.AdditionalDamage);
        }

        public abstract void Attack(IDamageable damageable);
        public void ApplyDamageUp(int additionalDamage)
        {
            _weaponData.AddDamage(additionalDamage);
        }
    }
}