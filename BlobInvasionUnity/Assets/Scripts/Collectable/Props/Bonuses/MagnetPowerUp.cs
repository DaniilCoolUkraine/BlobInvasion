using System.Collections;
using BlobInvasion.Collectable.Props.Bonuses.ScriptableObjects;
using BlobInvasion.Player;
using UnityEngine;

namespace BlobInvasion.Collectable.Props.Bonuses
{
    public class MagnetPowerUp : PowerUp
    {
        private MagnetPowerUpDataSO _magnetPowerUpData;
        
        private const int _maxCoinsPerTime = 10;
        private Collider[] _coins = new Collider[_maxCoinsPerTime];

        private void Awake()
        {
            _magnetPowerUpData = (MagnetPowerUpDataSO) _powerUpData;
        }

        protected override IEnumerator PowerUpCharacteristic(PlayerController playerController)
        {
            Physics.OverlapSphereNonAlloc(this.transform.position, _powerUpData.PowerMultiplier, _coins, LayerMask.NameToLayer("Coin"));

            foreach (Collider coin in _coins)
            {
                Debug.Log(coin);
                coin.GetComponent<Coin>().Collect(_magnetPowerUpData.PlayerCollector);
            }
            
            yield return new WaitForSeconds(_powerUpData.PoweringTime / _maxCoinsPerTime);
            
            Destroy(gameObject);
        }
    }
}