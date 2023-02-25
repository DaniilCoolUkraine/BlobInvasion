using UnityEngine;

namespace BlobInvasion.Items.Weapons.RangedWeapons
{
    public abstract class RangedWeapon: Weapon
    {
        public override void Attack(int additionalDamage)
        {
            Debug.Log("I'm ranged weapon");
        }
    }
}