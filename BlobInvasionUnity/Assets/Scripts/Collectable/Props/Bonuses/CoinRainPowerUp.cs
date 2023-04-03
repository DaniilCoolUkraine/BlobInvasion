using System.Collections;
using BlobInvasion.Collectable.Props.Bonuses.ScriptableObjects;
using BlobInvasion.Player;
using UnityEngine;

namespace BlobInvasion.Collectable.Props.Bonuses
{
    public class CoinRainPowerUp : PowerUp
    {
        private CoinRainPowerUpDataSO _coinRainPowerUpDataSO;
        
        private void Awake()
        {
            _coinRainPowerUpDataSO = (CoinRainPowerUpDataSO) _powerUpData;
        }

        protected override IEnumerator DoPowerUpCharacteristic(PlayerController playerController)
        {
            for (int i = 0; i < _coinRainPowerUpDataSO.PowerMultiplier; i++)
            {
                yield return new WaitForSeconds(_coinRainPowerUpDataSO.PoweringTime);
                
                Rigidbody coin = Instantiate(_coinRainPowerUpDataSO.Coin, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
                coin.AddExplosionForce(_coinRainPowerUpDataSO.ExplosionStrength, this.transform.position, _coinRainPowerUpDataSO.ExplosionStrength, _coinRainPowerUpDataSO.ExplosionStrength, ForceMode.Impulse);
            }

            Destroy(gameObject);
        }
    }
}