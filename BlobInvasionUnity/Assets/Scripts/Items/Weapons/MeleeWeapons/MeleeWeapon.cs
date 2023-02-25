using UnityEngine;

namespace BlobInvasion.Items.Weapons
{
    public abstract class MeleeWeapon: Weapon
    {
        public override void Attack(int additionalDamage)
        {
            Debug.Log("I'm melee weapon");
        }
    }
}