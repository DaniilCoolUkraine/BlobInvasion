using System;

namespace BlobInvasion.Damageable
{
    public interface IDamageable
    {
        public event Action OnDie;
        public void TaKeDamage(int damage);
    }
}