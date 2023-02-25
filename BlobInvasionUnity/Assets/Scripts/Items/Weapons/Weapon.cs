using BlobInvasion.Items.Weapons.ScriptableObjects;
using UnityEngine;

namespace BlobInvasion.Items.Weapons
{
    public abstract class Weapon : MonoBehaviour, IItem, IDamager
    {
        [SerializeField] private WeaponDataSO _weaponData;

        public abstract void Attack(int additionalDamage);
    }
}