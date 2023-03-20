using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace BlobInvasion.Collectable.Props
{
    public abstract class Item : MonoBehaviour, ICollectable
    {
        public event Action<bool> OnCollected;
        
        [SerializeField] protected ParticleSystem[] _collectParticles;
        
        private bool _isColected = false;
        public bool IsCollected
        {
            get => _isColected;
            set
            {
                _isColected = value;
                OnCollected?.Invoke(_isColected);
            }
        }

        public virtual void Collect(GameObject collector)
        {
            IsCollected = true;
            SpawnParticles(_collectParticles);
            Destroy(gameObject);
        }
        
        protected void SpawnParticles(ParticleSystem[] particles)
        {
            var particle = Instantiate(particles[Random.Range(0, particles.Length)],
                transform.position + Vector3.up, Quaternion.identity);
            particle.Play();

            Destroy(particle.gameObject, particle.duration);
        }
    }
}