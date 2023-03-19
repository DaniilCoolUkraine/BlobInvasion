using UnityEngine;

namespace BlobInvasion.Damageable
{
    public class EnemyHealth : Health
    {
        [SerializeField] private ParticleSystem[] _onTakeDamageParticles;
        [SerializeField] private GameObject[] _propsDrop;

        public override void TaKeDamage(int damage)
        {
            base.TaKeDamage(damage);
            
            SpawnParticles(_onTakeDamageParticles);
        }

        protected override void Die()
        {
            Instantiate(_propsDrop[Random.Range(0, _propsDrop.Length)], transform.position + Vector3.up, Quaternion.identity);
            base.Die();
        }
    }
}