using BlobInvasion.Enemies.Spawner;
using BlobInvasion.Player;
using BlobInvasion.Settings;
using UnityEngine;

namespace BlobInvasion.GameManagers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private PlayerSettingsSO _playerSettings;
        [SerializeField] private LevelSettingsSO _levelSettings;

        [SerializeField] private PlayerAttack _playerAttack;
        
        [SerializeField] private EnemyWaveSpawner _enemyWaveSpawner;
        [SerializeField] private BossSpawner _bossSpawner;
        
        private void Awake()
        {
            _playerSettings.RestoreSavedWeapon();
            _levelSettings.RestoreSavedScene();
        }

        private void OnEnable()
        {
            _playerAttack.OnGoalReached += OnGoalReached;
        }
        
        private void OnDisable()
        {
            _playerAttack.OnGoalReached -= OnGoalReached;
        }

        private void OnGoalReached()
        {
            _enemyWaveSpawner.gameObject.SetActive(false);
            _bossSpawner.gameObject.SetActive(true);
        }
    }
}