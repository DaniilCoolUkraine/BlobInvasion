using System;
using BlobInvasion.Damageable.ScriptableObjects;
using UnityEngine;
using Random = UnityEngine.Random;

namespace BlobInvasion.Damageable
{
    public abstract class Health : MonoBehaviour, IDamageable
    {
        [SerializeField] private HealthData _healthData;

        [SerializeField] private ParticleSystem[] _dieParticles;

        private int _currentHp;

        private void Start()
        {
            _currentHp = _healthData.MaxHp;
        }

        public event Action OnHealthIsZero;
        public event Action<float, float> OnDamageTaken;

        public virtual void TaKeDamage(int damage)
        {
            _currentHp -= damage;
            OnDamageTaken?.Invoke(_currentHp, _healthData.MaxHp);

            if (_currentHp<=0)
                Die();
        }

        protected virtual void Die()
        {
            OnHealthIsZero?.Invoke();

            SpawnParticles(_dieParticles);
                
            Destroy(gameObject);
        }

        protected void SpawnParticles(ParticleSystem[] particles)
        {
            var particle = Instantiate(particles[Random.Range(0, particles.Length)],
                transform.position + Vector3.up, Quaternion.identity);
            particle.Play();

            Destroy(particle.gameObject, particle.main.duration);
        }
    }
}