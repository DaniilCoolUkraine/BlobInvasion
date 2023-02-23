using UnityEngine;

namespace BlobInvasion
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private PlayerMovement _player;
        //change manager to controller
        [SerializeField] private PlayerAnimationManager _animationManager;

        private void OnEnable()
        {
            _player.OnPlayerMove += _animationManager.PlayMovementAnimation;
        }

        private void OnDisable()
        {
            _player.OnPlayerMove -= _animationManager.PlayMovementAnimation;
        }
    }
}