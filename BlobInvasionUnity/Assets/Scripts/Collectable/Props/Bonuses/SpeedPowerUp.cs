using System.Collections;
using BlobInvasion.Player;
using UnityEngine;

namespace BlobInvasion.Collectable.Props.Bonuses
{
    public class SpeedPowerUp : PowerUp
    {
        protected override IEnumerator PowerUpCharacteristic(PlayerController playerController)
        {
            playerController.PlayerMovement.ApplyPowerUp(_powerUpData.PowerMultiplier);

            yield return new WaitForSeconds(_powerUpData.PoweringTime);

            playerController.PlayerMovement.ApplyPowerUp(-_powerUpData.PowerMultiplier);
            
            Destroy(gameObject);
        }
    }
}