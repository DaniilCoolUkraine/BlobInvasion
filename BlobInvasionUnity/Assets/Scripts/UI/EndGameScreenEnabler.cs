using System;
using BlobInvasion.ScriptableObjects;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BlobInvasion.UI
{
    public class EndGameScreenEnabler : MonoBehaviour
    {
        public event Action<bool> OnPaused;
        public bool IsPaused { get; protected set; } = false;
        
        [SerializeField] private ScriptableObjectEvent _onPlayerDieEvent;

        [SerializeField] private GameObject _looseScreen;
        [SerializeField] private GameObject _winScreen;
        
        [SerializeField] private GameObject _joystickCanvas;

        private void OnEnable()
        {
            _onPlayerDieEvent.OnInvoked += EnableLooseScreen;
        }

        private void OnDisable()
        {
            _onPlayerDieEvent.OnInvoked -= EnableLooseScreen;
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
    }
}
