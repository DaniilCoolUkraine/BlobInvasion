using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BlobInvasion.UI
{
    public class PauseMenu : MonoBehaviour
    {
        public event Action<bool> OnPaused;
        
        public bool IsPaused { get; private set; } = false;

        [SerializeField] private GameObject _pauseMenu;
        
        [SerializeField] private GameObject _looseScreen;
        [SerializeField] private GameObject _winScreen;
        
        [SerializeField] private GameObject _joystickCanvas;
        
        private void OnDisable()
        {
            Time.timeScale = 1f;
        }

        public void EnableLooseScreen()
        {
            IsPaused = true;
            OnPaused?.Invoke(true);
            Time.timeScale = 0f;
            
            _looseScreen.SetActive(true);
            _joystickCanvas.SetActive(false);
        }
        
        public void EnableWinScreen()
        {
            IsPaused = true;
            OnPaused?.Invoke(true);
            Time.timeScale = 0f;
            
            _winScreen.SetActive(true);
            _joystickCanvas.SetActive(false);
        }
        
        public void Pause()
        {
            IsPaused = true;
            OnPaused?.Invoke(true);
            Time.timeScale = 0f;
            
            _pauseMenu.SetActive(true);
            _joystickCanvas.SetActive(false);
        }
        
        public void Resume()
        {
            IsPaused = false;
            OnPaused?.Invoke(false);
            Time.timeScale = 1f;
            
            _pauseMenu.SetActive(false);
            _joystickCanvas.SetActive(true);
        }

        public void Quit()
        {
            Application.Quit();
        }

        public void LoadMenu()
        {
            string sceneName = "MainMenuScene";
            SceneManager.LoadScene(sceneName);
        }

        public void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
