using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BlobInvasion.UI
{
    public class PauseMenu : MonoBehaviour
    {
        public bool IsPaused { get; private set; } = false;

        [SerializeField] private GameObject _pauseMenu;
        [SerializeField] private GameObject _joystickCanvas;
        
        private void Update()
        {
            if (!Input.GetKeyDown(KeyCode.Escape))
            {
                return;
            }
            
            if (IsPaused)
            {
                Resume();
                return;
            }

            Pause();
        }

        private void OnDisable()
        {
            Time.timeScale = 1f;
        }

        public void Resume()
        {
            IsPaused = false;
            Time.timeScale = 1f;
            
            _pauseMenu.SetActive(false);
            _joystickCanvas.SetActive(true);
        }
        
        public void Pause()
        {
            IsPaused = true;
            Time.timeScale = 0f;
            
            _pauseMenu.SetActive(true);
            _joystickCanvas.SetActive(false);
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
    }
}
