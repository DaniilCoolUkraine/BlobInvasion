using System;
using UnityEngine;

namespace BlobInvasion.UI
{
    public class ButtonPauseMenu : ButtonActionSubscriber
    {
        public event Action<bool> OnPaused;
        public static bool IsPaused { get; private set; } = false;
        
        [SerializeField] private GameObject _pauseMenu;
        [SerializeField] private GameObject _joystickCanvas;

        protected override void OnButtonClicked()
        {
            if (IsPaused)
            {
                OpenPauseMenu();
            }
            else
            {
                ClosePauseMenu();
            }
            
            OnPaused?.Invoke(IsPaused);
        }

        private void ClosePauseMenu()
        {
            IsPaused = true;
            Time.timeScale = 0f;

            _pauseMenu.SetActive(true);
            _joystickCanvas.SetActive(false);
        }

        private void OpenPauseMenu()
        {
            IsPaused = false;
            Time.timeScale = 1f;

            _pauseMenu.SetActive(false);
            _joystickCanvas.SetActive(true);
        }
    }
}