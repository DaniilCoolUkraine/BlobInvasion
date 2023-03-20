using UnityEngine;

namespace BlobInvasion.Collectable.Props.Bonuses
{
    public abstract class PowerUp : Item, IPowerUp
    {
        [SerializeField] protected MeshRenderer _meshRenderer;
        [SerializeField] protected Collider _collider;
        
        public override void Collect(GameObject collector)
        {
            IsCollected = true;

            SpawnParticles(_collectParticles);
            
            _meshRenderer.enabled = false;
            _collider.enabled = false;
        }

        public abstract void UsePowerUp(IPowerable powerable);
    }
}