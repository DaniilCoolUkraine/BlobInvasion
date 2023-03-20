using System.Collections;
using UnityEngine;

namespace BlobInvasion.Collectable.Props.Bonuses
{
    public class DamagePowerUp : PowerUp
    {
        [SerializeField] private int _additionalDamage;
        [SerializeField] private float _time;
        
        public override void UsePowerUp(IPowerable powerable)
        {
            StartCoroutine(DamageUp(powerable));
        }
        
        private IEnumerator DamageUp(IPowerable powerable)
        {
            powerable.ApplyPowerUp(_additionalDamage);
            
            yield return new WaitForSeconds(_time);

            powerable.ApplyPowerUp(-_additionalDamage);
            
            Destroy(gameObject);
        }
    }
}