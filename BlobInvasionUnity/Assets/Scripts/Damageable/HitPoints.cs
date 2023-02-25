using UnityEngine;

namespace BlobInvasion.Damageable
{
    public class HitPoints : MonoBehaviour, IDamageable
    {
        [SerializeField] private int _maxHp;
        public int CurrentHp { get; private set; }

        private void Start()
        {
            CurrentHp = _maxHp;
        }

        public void TaKeDamage(int damage)
        {
            CurrentHp -= damage;

            if (CurrentHp<=0)
                Die();
        }

        private void Die()
        {
            Debug.Log($"{gameObject.name} died");
        }
    }
}