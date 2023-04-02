using BlobInvasion.Settings;
using UnityEngine;

namespace BlobInvasion.GameManagers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private PlayerSettingsSO _playerSettings;
        [SerializeField] private LevelSettingsSO _levelSettings;
        
        private void Awake()
        {
            _playerSettings.RestoreSavedWeapon();
            _levelSettings.RestoreSavedScene();
        }
    }
}