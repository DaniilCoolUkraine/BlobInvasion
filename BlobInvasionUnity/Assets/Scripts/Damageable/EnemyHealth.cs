using UnityEngine;

namespace BlobInvasion.Damageable
{
    public class EnemyHealth : Health
    {
        [SerializeField] private GameObject[] _propsDrop;
        
        protected override void Die()
        {
            Instantiate(_propsDrop[Random.Range(0, _propsDrop.Length)], transform.position + Vector3.up, Quaternion.identity);
            base.Die();
        }
    }
}