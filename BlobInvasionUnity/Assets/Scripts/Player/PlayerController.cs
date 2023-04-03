using BlobInvasion.Collectable.Props.Bonuses;
using BlobInvasion.Damageable;
using BlobInvasion.Enemies.Spawner;
using BlobInvasion.ScriptableObjects;
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
        
        [Header("Events")] 
        [SerializeField] private ScriptableObjectEvent _playerDieEvent;
        
        public PlayerAttack PlayerAttack => _playerAttack;
        public MoveByPhysicsJoysticController PlayerMovement => _playerMovement;
        public PlayerHealth PlayerHealth => _playerHealth;
        
        private void OnEnable()
        {
            _playerMovement.OnPlayerMove += _animationController.PlayMovementAnimation;
            _playerAttack.OnAttack += _animationController.PlayAttackAnimation;

            _playerCollector.OnCollected += OnCollected;

            _playerHealth.OnHealthIsZero += OnHealthIsZero;
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
    }
}