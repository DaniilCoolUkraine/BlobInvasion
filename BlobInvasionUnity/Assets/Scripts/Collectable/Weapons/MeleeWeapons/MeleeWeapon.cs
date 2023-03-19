using BlobInvasion.Damageable;

namespace BlobInvasion.Collectable.Weapons.MeleeWeapons
{
    public class MeleeWeapon: Weapon
    {
        public override void Attack(IDamageable damageable)
        {
            damageable.TaKeDamage(_weaponData.Damage + _weaponData.AdditionalDamage);
        }
    }
}