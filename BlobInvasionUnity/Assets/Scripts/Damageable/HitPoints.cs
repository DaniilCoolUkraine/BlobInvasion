using System;
using UnityEngine;

namespace BlobInvasion.Damageable
{
    public class HitPoints : MonoBehaviour, IDamageable
    {
        [SerializeField] private int _maxHp;
        private int _currentHp;

        private void Start()
        {
            _currentHp = _maxHp;
        }

        public event Action OnDie;
        public event Action<float, float> OnDamageTaken;

        public void TaKeDamage(int damage)
        {
            _currentHp -= damage;
            OnDamageTaken?.Invoke(_maxHp, _currentHp);

            if (_currentHp<=0)
                Die();
        }

        private void Die()
        {
            OnDie?.Invoke();
            Destroy(gameObject);
        }
    }
}