using BlobInvasion.Collectable.Props.Bonuses;
using BlobInvasion.Collectable.Weapons;
using BlobInvasion.Damageable;
using BlobInvasion.Enemies.Spawner;
using BlobInvasion.ScriptableObjects;
using BlobInvasion.Settings;
using BlobInvasion.UI;
using UnityEngine;

namespace BlobInvasion.Player
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Animatable/powerable")]
        
        [SerializeField] private MoveByPhysicsJoysticController _playerMovement;
        [SerializeField] private PlayerAttack _playerAttack;

        [SerializeField] private PlayerAnimationController _animationController;
        
        [Header("Powerable")]
     
        [SerializeField] private PlayerHealth _playerHealth;
        [SerializeField] private PlayerCollector _playerCollector;

        [Header("Weapons")]

        [SerializeField] private WeaponManager _weaponManager;
        [SerializeField] private PlayerSettingsSO _playerSettings;
        [SerializeField] private LevelSettingsSO _levelSettings;

        [Header("Events")] 
        [SerializeField] private ScriptableObjectEvent _playerDieEvent;
        
        [Header("Enemies")]
        
        [SerializeField] private EnemyWaveSpawner[] _enemyWaveSpawners;

        public PlayerAttack PlayerAttack => _playerAttack;
        public MoveByPhysicsJoysticController PlayerMovement => _playerMovement;
        public PlayerHealth PlayerHealth => _playerHealth;

        private void Awake()
        {
            _playerSettings.RestoreSavedWeapon();
            _levelSettings.RestoreSavedScene();
        }

        private void Start()
        {
            _weaponManager.CreateWeapon(_playerSettings.CurrentWeapon);
        }

        private void OnEnable()
        {
            _playerMovement.OnPlayerMove += _animationController.PlayMovementAnimation;
            _playerAttack.OnAttack += _animationController.PlayAttackAnimation;

            _playerCollector.OnCollected += OnCollected;

            _playerHealth.OnHealthIsZero += OnHealthIsZero;

            _playerAttack.OnGoalReached += OnGoalReached;
        }

        private void OnDisable()
        {
            _playerMovement.OnPlayerMove -= _animationController.PlayMovementAnimation;
            _playerAttack.OnAttack -= _animationController.PlayAttackAnimation;
            
            _playerCollector.OnCollected -= OnCollected;
            
            _playerHealth.OnHealthIsZero -= OnHealthIsZero;
        }
        
        private void OnCollected(GameObject collectedGameObject)
        {
            IPowerUp powerUp = collectedGameObject.GetComponent<IPowerUp>();

            if (powerUp != null)
            {
                powerUp.UsePowerUp(this);
            }
        }

        private void OnHealthIsZero()
        {
            _playerDieEvent.Invoke();
        }
        
        private void OnGoalReached()
        {
            foreach (EnemyWaveSpawner spawner in _enemyWaveSpawners)
            {
                spawner.gameObject.SetActive(!spawner.gameObject.activeSelf);
            }
        }
    }
}