using System.Linq;
using BlobInvasion.Collectable.Weapons;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BlobInvasion.Player
{
    [CreateAssetMenu(fileName = "NewPlayerSettings", menuName = "ScriptableObjects/PlayerSettings", order = 0)]
    public class PlayerSettingsSO : ScriptableObject
    {
        [SerializeField] private Weapon[] _weapons;
        [SerializeField] private Weapon _currentWeapon;

        [Space(10)]
        
        [SerializeField] private string[] _scenes;
        [SerializeField] private string _currentScene;
        
        public Weapon CurrentWeapon => _currentWeapon;
        
        private string _savedWeaponKey = "PLAYER_SELECTED_WEAPON";
        private string _savedSceneKey = "PLAYER_SELECTED_SCENE";

        public void SetWeapon(Weapon weapon)
        {
            _currentWeapon = weapon;

            PlayerPrefs.SetString(_savedWeaponKey, weapon.name);
        }

        public void SetScene(string sceneName)
        {
            _currentScene = sceneName;
            
            PlayerPrefs.SetString(_savedSceneKey, sceneName);
        }

        public void RestoreSavedWeapon()
        {
            string weaponName = PlayerPrefs.GetString(_savedWeaponKey);

            _currentWeapon = _weapons.FirstOrDefault(x => x.name == weaponName);
        }
        
        public void RestoreSavedScene()
        {
            string sceneName = PlayerPrefs.GetString(_savedSceneKey);

            _currentScene = _scenes.FirstOrDefault(x => x == sceneName);
        }
    }
}