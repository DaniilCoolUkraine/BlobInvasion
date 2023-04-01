using BlobInvasion.Settings;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BlobInvasion.Shop
{
    public class LevelsManager : MonoBehaviour
    {
        [SerializeField] private LevelSettingsSO _levelSettings;
        
        public void LoadCurrentScene()
        {
            SceneManager.LoadScene(_levelSettings.CurrentScene);
        }
        
        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}