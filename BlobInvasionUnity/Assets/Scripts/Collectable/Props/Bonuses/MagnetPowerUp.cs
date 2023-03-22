using System.Collections;
using BlobInvasion.Collectable.Props.Bonuses.ScriptableObjects;
using UnityEngine;

namespace BlobInvasion.Collectable.Props.Bonuses
{
    public class MagnetPowerUp : PowerUp
    {
        private MagnetPowerUpDataSO _magnetPowerUpData;
        
        private void Awake()
        {
            _magnetPowerUpData = (MagnetPowerUpDataSO) _powerUpData;
        }

        protected override IEnumerator DoPowerUp(IPowerable powerable)
        {
            powerable.Apply(_magnetPowerUpData.MaxDistance);

            yield return new WaitForSeconds(_powerUpData.PoweringTime);
            
            powerable.Discard(-_magnetPowerUpData.MaxDistance);
        }
    }
}