using UnityEngine;

namespace BlobInvasion.Player
{
    public class PlayerAnimationController : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        
        private string _isRunningParameter = "isRunning";
        
        public void PlayMovementAnimation(bool isRunning)
        {
            _animator.SetBool(_isRunningParameter, isRunning);
        }
    }
}