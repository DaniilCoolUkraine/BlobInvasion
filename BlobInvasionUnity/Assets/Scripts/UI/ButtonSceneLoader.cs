using BlobInvasion.Settings;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BlobInvasion.UI
{
    public class ButtonSceneLoader : ButtonActionSubscriber
    {
        [SerializeField] private string _sceneName;
        [SerializeField] private LevelSettingsSO _levelSettings;
        [SerializeField] private bool _isQuitButton;
        
        protected override void OnButtonClicked()
        {
            if (_isQuitButton)
            {
                Application.Quit();
            }
            
            if (string.IsNullOrEmpty(_sceneName))
            {
                SceneManager.LoadScene(_levelSettings.CurrentScene);
            }
            else
            {
                SceneManager.LoadScene(_sceneName);
            }
        }
    }
}