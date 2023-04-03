using System.Collections;
using BlobInvasion.Collectable.Props.Bonuses.ScriptableObjects;
using BlobInvasion.Player;
using UnityEngine;

namespace BlobInvasion.Collectable.Props.Bonuses
{
    public abstract class PowerUp : Item, IPowerUp
    {
        [SerializeField] protected MeshRenderer _meshRenderer;
        [SerializeField] protected SphereCollider _collider;

        [Space(10)]
        
        [SerializeField] protected PowerUpDataSO _powerUpData;
        
        public override void Collect(GameObject collector)
        {
            IsCollected = true;

            SpawnParticles(_collectParticles);
            
            _meshRenderer.enabled = false;
            _collider.enabled = false;
        }

        public virtual void UsePowerUp(PlayerController playerController)
        {
            if (playerController == null)
                return;
            
            StartCoroutine(DoPowerUpCharacteristic(playerController));
        }

        protected abstract IEnumerator DoPowerUpCharacteristic(PlayerController playerController);
    }
}