using BlobInvasion.Collectable.Props.Bonuses;
using BlobInvasion.Damageable;
using UnityEngine;

namespace BlobInvasion.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private MoveByPhysicsJoysticController _playerMovement;
        [SerializeField] private PlayerAttack _playerAttack;

        [SerializeField] private PlayerHealth _playerHealth;

        [SerializeField] private PlayerCollector _playerCollector;

        public PlayerAttack PlayerAttack => _playerAttack;
        public MoveByPhysicsJoysticController PlayerMovement => _playerMovement;
        public PlayerHealth PlayerHealth => _playerHealth;
        
        [SerializeField] private PlayerAnimationController _animationController;

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