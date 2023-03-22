using System;
using BlobInvasion.Collectable.Props;
using BlobInvasion.Collectable.Props.Bonuses;
using BlobInvasion.General;
using UnityEngine;

namespace BlobInvasion.Player
{
    public class PlayerMagnetPowerUp : MonoBehaviour, IPowerable
    {
        public bool IsActive { get; set; }
        
        [SerializeField] private SphereCollider _collider;

        public void Apply(params object[] param)
        {
            // Physics.OverlapSphereNonAlloc(this.transform.position, _powerUpData.CharacteristicMultiplier, _coins, LayerMask.NameToLayer("Coin"));
            //
            // foreach (Collider coin in _coins)
            // {
            //     Debug.Log(coin);
            //     coin.GetComponent<Coin>().Collect(_magnetPowerUpData.PlayerCollector);
            // }

            if (param == null || param.Length == 0 || !(param[0] is float))
            {
                return;
            }
            
            _collider.radius = (float) param[0];
            IsActive = true;
        }

        public void Discard(params object[] param)
        {
            if (param == null || param.Length == 0 || !(param[0] is float))
            {
                return;
            }
            
            _collider.radius = (float) param[0];
            IsActive = false;
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag(Constants.COIN_TAG))
            {
                Coin coin = other.GetComponent<Coin>();
            }
        }
    }
}