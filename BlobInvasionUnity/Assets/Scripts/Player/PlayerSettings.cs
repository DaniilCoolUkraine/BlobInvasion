using BlobInvasion.Collectable.Weapons;
using UnityEngine;

namespace BlobInvasion.Player
{
    [CreateAssetMenu(fileName = "NewPlayerSettings", menuName = "ScriptableObjects/PlayerSettings", order = 0)]
    public class PlayerSettings : ScriptableObject
    {
        [SerializeField] private Weapon _currentWeapon;
        public Weapon CurrentWeapon => _currentWeapon;

        public void SetWeapon(Weapon weapon)
        {
            _currentWeapon = weapon;
        }
    }
}