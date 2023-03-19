using System;

namespace BlobInvasion.Damageable
{
    public interface IDamageable
    {
        public event Action OnDie;
        public event Action<float, float> OnDamageTaken;
        public void TaKeDamage(int damage);
    }
}