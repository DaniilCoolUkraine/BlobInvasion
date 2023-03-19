using System.Collections;
using BlobInvasion.Collectable.Weapons.ScriptableObjects;
using UnityEngine;

namespace BlobInvasion.Collectable.Props.Bonuses
{
    public class DamagePowerUp : PowerUp
    {
        [SerializeField] private WeaponDataSO[] _weapons;
        
        [SerializeField] private int _additionalDamage;
        [SerializeField] private float _time;
        
        public override void ApplyPowerUp()
        {
            StartCoroutine(DamageUp());
        }

        private IEnumerator DamageUp()
        {
            foreach (WeaponDataSO weapon in _weapons)
                weapon.AddDamage(_additionalDamage);
            
            yield return new WaitForSeconds(_time);

            foreach (WeaponDataSO weapon in _weapons)
                weapon.AddDamage(-_additionalDamage);
            
            Destroy(gameObject);
        }
    }
}