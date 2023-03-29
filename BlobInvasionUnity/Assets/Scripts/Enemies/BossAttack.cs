using BlobInvasion.Damageable;
using UnityEngine;

namespace BlobInvasion.Enemies
{
    public class BossAttack : MonoBehaviour
    {
        [SerializeField] private BossAttackDataSO _bossAttackData;

        private void Attack()
        {
            Collider[] colliderInfo = Physics.OverlapSphere(transform.position, _bossAttackData.AttackRadius);
            
            foreach (Collider collider in colliderInfo)
            {
                IDamageable damageable = collider.transform.GetComponent<IDamageable>();
                if (damageable == null)
                    continue;
                
                damageable.TaKeDamage(_bossAttackData.Damage);
            }
        }
    }
}