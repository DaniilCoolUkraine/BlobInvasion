using BlobInvasion.Damageable;
using UnityEngine;

namespace BlobInvasion.Enemies
{
    public class BossAttack : MonoBehaviour
    {
        [SerializeField] private BossAttackDataSO _bossAttackData;

        private IDamageable _damageable;

        public void SetDamageable(IDamageable damageable)
        {
            _damageable = damageable;
        }
        
        private void Attack()
        {
            _damageable.TaKeDamage(_bossAttackData.Damage);
        }
    }
}