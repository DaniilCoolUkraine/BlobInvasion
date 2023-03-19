﻿using System;
using BlobInvasion.Damageable.ScriptableObjects;
using UnityEngine;

namespace BlobInvasion.Damageable
{
    public class Health : MonoBehaviour, IDamageable
    {
        [SerializeField] private HealthData _healthData;

        [SerializeField] private ParticleSystem _dieParticles;

        private int _currentHp;

        private void Start()
        {
            _currentHp = _healthData.MaxHp;
        }

        public event Action OnDie;
        public event Action<float, float> OnDamageTaken;

        public void TaKeDamage(int damage)
        {
            _currentHp -= damage;
            OnDamageTaken?.Invoke(_currentHp, _healthData.MaxHp);

            if (_currentHp<=0)
                Die();
        }

        private void Die()
        {
            OnDie?.Invoke();
            var particles = Instantiate(_dieParticles, transform.position + Vector3.up, Quaternion.identity);
            particles.Play();

            Destroy(particles.gameObject, particles.duration);
            Destroy(gameObject);
        }
    }
}