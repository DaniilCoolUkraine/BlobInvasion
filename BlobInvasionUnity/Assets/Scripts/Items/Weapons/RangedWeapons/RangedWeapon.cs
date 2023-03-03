using BlobInvasion.Damageable;
using UnityEngine;

namespace BlobInvasion.Items.Weapons
{
    public abstract class RangedWeapon: Weapon
    {
        public override void Attack(IDamageable damageable)
        {
            Debug.Log("I'm ranged weapon");
        }
    }
}