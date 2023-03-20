using System.Collections;
using UnityEngine;

namespace BlobInvasion.Collectable.Props.Bonuses
{
    public class DamagePowerUp : PowerUp
    {
        public override void UsePowerUp(IPowerable powerable)
        {
            if (powerable == null)
                return;
            
            StartCoroutine(DamageUp(powerable));
        }
        
        private IEnumerator DamageUp(IPowerable powerable)
        {
            powerable.ApplyPowerUp(_powerUpData.PowerMultiplier);
            
            yield return new WaitForSeconds(_powerUpData.PoweringTime);

            powerable.ApplyPowerUp(-_powerUpData.PowerMultiplier);
            
            Destroy(gameObject);
        }
    }
}