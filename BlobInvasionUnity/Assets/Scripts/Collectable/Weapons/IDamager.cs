using BlobInvasion.Damageable;

namespace BlobInvasion.Collectable.Weapons
{
    public interface IDamager
    {
        public void Attack(IDamageable damageable);
    }
}