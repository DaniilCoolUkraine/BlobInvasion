using System.Collections;
using BlobInvasion.Collectable.Props.Bonuses.ScriptableObjects;
using BlobInvasion.Player;
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

        public override void Collect(GameObject collector)
        {
            base.Collect(collector);

            transform.parent = collector.transform;
        }

        protected override IEnumerator DoPowerUpCharacteristic(PlayerController playerController)
        {
            _collider.isTrigger = true;
            _collider.enabled = true;
            _collider.radius = _magnetPowerUpData.PowerMultiplier;
            
            yield return new WaitForSeconds(_magnetPowerUpData.PoweringTime);
            
            Destroy(gameObject);
        }

        private void OnTriggerStay(Collider other)
        {
            Coin _coin = other.transform.GetComponent<Coin>();

            if (_coin == null)
            {
                return;
            }

            _coin.transform.position = Vector3.MoveTowards(_coin.transform.position, this.transform.position,
                _magnetPowerUpData.MagnetStrength * Time.deltaTime);
        }
    }
}