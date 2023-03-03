using BlobInvasion.Damageable;

namespace BlobInvasion.Items.Weapons
{
    public interface IDamager
    {
        public void Attack(IDamageable damageable);
    }
}