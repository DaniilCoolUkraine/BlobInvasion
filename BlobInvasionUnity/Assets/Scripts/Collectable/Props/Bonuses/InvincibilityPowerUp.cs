using System.Collections;
using BlobInvasion.Player;
using UnityEngine;

namespace BlobInvasion.Collectable.Props.Bonuses
{
    public class InvincibilityPowerUp : PowerUp
    {
        protected override IEnumerator PowerUpCharacteristic(PlayerController playerController)
        {
            playerController.PlayerHealth.ApplyPowerUp(-_powerUpData.PowerMultiplier);
            
            yield return new WaitForSeconds(_powerUpData.PoweringTime);
            
            playerController.PlayerHealth.ApplyPowerUp(_powerUpData.PowerMultiplier);
            
            Destroy(gameObject);
        }
    }
}