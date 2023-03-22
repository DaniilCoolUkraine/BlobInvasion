using System.Collections;
using UnityEngine;

namespace BlobInvasion.Collectable.Props.Bonuses
{
    public class CharacteristicsIncreasePowerUp : PowerUp
    {
        protected override IEnumerator DoPowerUp(IPowerable powerable)
        {
            powerable.Apply(_powerUpData.CharacteristicMultiplier);

            yield return new WaitForSeconds(_powerUpData.PoweringTime);

            powerable.Discard(_powerUpData.CharacteristicMultiplier);

            Destroy(gameObject);
        }
    }
}