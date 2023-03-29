using System;
using BlobInvasion.Damageable;
using UnityEngine;

namespace BlobInvasion.Enemies
{
    public class BossTriggerDetector : MonoBehaviour
    {
        public event Action<bool> OnTriggered;

        [SerializeField] private SphereCollider _attackTrigger;
        [SerializeField] private BossAttackDataSO _bossAttackData;

        private void Start()
        {
            _attackTrigger.radius = _bossAttackData.AttackRadius;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.transform.GetComponent<IDamageable>() != null)
            {
                OnTriggered?.Invoke(true);   
            }
        }
        
        private void OnTriggerExit(Collider other)
        {
            if (other.transform.GetComponent<IDamageable>() != null)
            {
                OnTriggered?.Invoke(false);   
            }
        }
    }
}