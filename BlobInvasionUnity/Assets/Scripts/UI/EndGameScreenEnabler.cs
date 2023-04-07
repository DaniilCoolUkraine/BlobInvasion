using System;
using BlobInvasion.ScriptableObjects;
using UnityEngine;

namespace BlobInvasion.UI
{
    public class EndGameScreenEnabler : MonoBehaviour
    {
        public event Action<bool> OnPaused;
        public bool IsPaused { get; protected set; } = false;
        
        [SerializeField] private ScriptableObjectEvent _onPlayerDieEvent;
        [SerializeField] private ScriptableObjectEvent _onBossKilledEvent;

        [SerializeField] private GameObject _looseScreen;
        [SerializeField] private GameObject _winScreen;
        
        [SerializeField] private GameObject _joystickCanvas;

        private void OnEnable()
        {
            _onPlayerDieEvent.OnInvoked += EnableLooseScreen;
            _onBossKilledEvent.OnInvoked += EnableWinScreen;
        }

        private void OnDisable()
        {
            _onPlayerDieEvent.OnInvoked -= EnableLooseScreen;
            _onBossKilledEvent.OnInvoked -= EnableWinScreen;

            Time.timeScale = 1f;
        }

        private void EnableLooseScreen()
        {
            IsPaused = true;
            OnPaused?.Invoke(true);
            Time.timeScale = 0f;
            
            _looseScreen.SetActive(true);
            _joystickCanvas.SetActive(false);
        }
        
        private void EnableWinScreen()
        {
            IsPaused = true;
            OnPaused?.Invoke(true);
            Time.timeScale = 0f;
            
            _winScreen.SetActive(true);
            _joystickCanvas.SetActive(false);
        }
    }
}
