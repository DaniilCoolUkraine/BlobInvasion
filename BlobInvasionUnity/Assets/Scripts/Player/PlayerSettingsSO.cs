using System.Linq;
using BlobInvasion.Collectable.Weapons;
using UnityEngine;

namespace BlobInvasion.Player
{
    [CreateAssetMenu(fileName = "NewPlayerSettings", menuName = "ScriptableObjects/PlayerSettings", order = 0)]
    public class PlayerSettingsSO : ScriptableObject
    {
        [SerializeField] private Weapon[] _weapons;
        [SerializeField] private Weapon _currentWeapon;
        public Weapon CurrentWeapon => _currentWeapon;
        
        private string _savedKey = "PLAYER_SELECTED_WEAPON";

        public void SetWeapon(Weapon weapon)
        {
            _currentWeapon = weapon;

            PlayerPrefs.SetString(_savedKey, weapon.name);
        }

        public void RestoreSavedWeapon()
        {
            string weaponName = PlayerPrefs.GetString(_savedKey);

            _currentWeapon = _weapons.FirstOrDefault(x => x.name == weaponName);
        }
    }
}