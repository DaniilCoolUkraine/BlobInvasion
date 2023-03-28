using System;
using BlobInvasion.Collectable.Props.Bonuses;
using BlobInvasion.Collectable.Weapons;
using BlobInvasion.Damageable;
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
        [SerializeField] private PlayerSettingsSO playerSettings;

        public PlayerAttack PlayerAttack => _playerAttack;
        public MoveByPhysicsJoysticController PlayerMovement => _playerMovement;
        public PlayerHealth PlayerHealth => _playerHealth;

        private void Awake()
        {
            playerSettings.RestoreSavedWeapon();
            playerSettings.RestoreSavedScene();
        }

        private void Start()
        {
            _weaponManager.CreateWeapon(playerSettings.CurrentWeapon);
        }

        private void OnEnable()
        {
            _playerMovement.OnPlayerMove += _animationController.PlayMovementAnimation;
            _playerAttack.OnAttack += _animationController.PlayAttackAnimation;

            _playerCollector.OnCollected += OnCollected;
        }

        private void OnDisable()
        {
            _playerMovement.OnPlayerMove -= _animationController.PlayMovementAnimation;
            _playerAttack.OnAttack -= _animationController.PlayAttackAnimation;
            
            _playerCollector.OnCollected -= OnCollected;
        }

        private void OnCollected(GameObject collectedGameObject)
        {
            IPowerUp powerUp = collectedGameObject.GetComponent<IPowerUp>();

            if (powerUp != null)
            {
                powerUp.UsePowerUp(this);
            }
        }
    }
}