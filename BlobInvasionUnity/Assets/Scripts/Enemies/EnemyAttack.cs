using System;
using System.Collections;
using BlobInvasion.Damageable;
using UnityEngine;

namespace BlobInvasion.Enemies
{
    public class EnemyAttack : MonoBehaviour
    {
        public event Action OnEnemyCollided;

        private IDamageable _damageable;
        
        private void OnCollisionEnter(Collision collision)
        {
            _damageable = collision.gameObject.GetComponent<IDamageable>();
            if (_damageable != null)
            {
                OnEnemyCollided?.Invoke();
                StartCoroutine(AttackTime());
            }
        }

        private void OnCollisionExit(Collision other)
        {
            _damageable = null;
        }

        private IEnumerator AttackTime()
        {
            yield return new WaitForSeconds(1);
            _damageable?.TaKeDamage(1);
        }
    }
}