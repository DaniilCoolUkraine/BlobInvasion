using BlobInvasion.Damageable;

namespace BlobInvasion.Items.Weapons
{
    public abstract class MeleeWeapon: Weapon
    {
        public override void Attack(IDamageable damageable)
        {
            damageable.TaKeDamage(Damage);
        }
    }
}