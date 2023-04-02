using System;

namespace BlobInvasion.Damageable
{
    public interface IDamageable
    {
        public event Action OnHealthIsZero;
        public event Action<float, float> OnDamageTaken;
        public void TaKeDamage(int damage);
    }
}