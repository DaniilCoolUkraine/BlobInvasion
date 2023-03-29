using System;
using BlobInvasion.Damageable;
using UnityEngine;

namespace BlobInvasion.Enemies
{
    public class BossTriggerDetector : MonoBehaviour
    {
        public event Action<bool, IDamageable> OnTriggered;

        [SerializeField] private SphereCollider _attackTrigger;
        [SerializeField] private BossAttackDataSO _bossAttackData;

        private void Start()
        {
            _attackTrigger.radius = _bossAttackData.AttackRadius;
        }

        private void OnTriggerEnter(Collider other)
        {
            IDamageable damageable = other.transform.GetComponent<IDamageable>();
            if (damageable != null)
            {
                OnTriggered?.Invoke(true, damageable);   
                damageable.OnDie += () => StopAttack();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.transform.GetComponent<IDamageable>() != null)
            {
                StopAttack();
            }
        }
        
        private void StopAttack()
        {
            OnTriggered?.Invoke(false, null);
        }
    }
}