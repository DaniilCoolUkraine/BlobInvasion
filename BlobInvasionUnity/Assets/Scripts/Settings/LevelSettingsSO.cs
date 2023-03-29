using System.Linq;
using UnityEngine;

namespace BlobInvasion.Settings
{
    [CreateAssetMenu(fileName = "NewLevelSettings", menuName = "ScriptableObjects/LevelSettings", order = 0)]
    public class LevelSettingsSO : ScriptableObject
    {
        [SerializeField] private string[] _scenes;
        [SerializeField] private string _currentScene;
        
        private string _savedSceneKey = "PLAYER_SELECTED_SCENE";
        
        public void SetScene(string sceneName)
        {
            _currentScene = sceneName;
            
            PlayerPrefs.SetString(_savedSceneKey, sceneName);
        }
        
        public void RestoreSavedScene()
        {
            string sceneName = PlayerPrefs.GetString(_savedSceneKey);

            _currentScene = _scenes.FirstOrDefault(x => x == sceneName);
        }
    }
}