using UnityEngine;

namespace BlobInvasion.Player
{
    public class PlayerAnimationController : MonoBehaviour
    {
        [Tooltip("Animator component from child model")]
        [SerializeField] private Animator _animator;
        
        private string _isRunningParameter = "isRunning";
        private string _isAttackingParameter = "isAttacking";
        
        public void PlayMovementAnimation(bool isRunning)
        {
            _animator.SetBool(_isRunningParameter, isRunning);
        }
        
        public void PlayAttackAnimation(bool isAttacking)
        {
            //todo reset attacking state to false
            _animator.SetBool(_isAttackingParameter, isAttacking);
        }
    }
}