using System.Collections;
using BlobInvasion.Player;
using UnityEngine;

namespace BlobInvasion.Collectable.Props.Bonuses
{
    public class DamagePowerUp : PowerUp
    {
        protected override IEnumerator DoPowerUpCharacteristic(PlayerController playerController)
        {
            playerController.PlayerAttack.ApplyPowerUp(_powerUpData.PowerMultiplier);

            yield return new WaitForSeconds(_powerUpData.PoweringTime);

            playerController.PlayerAttack.ApplyPowerUp(-_powerUpData.PowerMultiplier);
            
            Destroy(gameObject);
        }
    }
}