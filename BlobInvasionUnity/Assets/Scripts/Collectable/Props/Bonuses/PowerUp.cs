using System.Collections;
using BlobInvasion.Collectable.Props.Bonuses.ScriptableObjects;
using UnityEngine;

namespace BlobInvasion.Collectable.Props.Bonuses
{
    public abstract class PowerUp : Item, IPowerUp
    {
        [SerializeField] protected MeshRenderer _meshRenderer;
        [SerializeField] protected Collider _collider;

        [Space(10)] 
        
        [SerializeField] protected PowerUpDataSO _powerUpData;
        
        [SerializeField] protected PowerUpType _type;
        public PowerUpType Type => _type;

        private Coroutine _doPowerUpCoroutine;
        
        public override void Collect(GameObject collector)
        {
            IsCollected = true;

            SpawnParticles(_collectParticles);
            
            _meshRenderer.enabled = false;
            _collider.enabled = false;
        }

        public virtual void UsePowerUp(IPowerable powerable)
        {
            if (powerable == null)
            {
                return;
            }
            
            if (_doPowerUpCoroutine != null)
            {
                StopCoroutine(_doPowerUpCoroutine);
            }
            
            _doPowerUpCoroutine = StartCoroutine(DoPowerUp(powerable));
        }

        protected abstract IEnumerator DoPowerUp(IPowerable powerable);
    }
}