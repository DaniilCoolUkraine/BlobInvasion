using UnityEngine;

namespace BlobInvasion.Player
{
    public class PlayerAnimationController : MonoBehaviour
    {
        [Tooltip("Animator component from child model")]
        [SerializeField] private Animator _animator;

        private int _attackLayerIndex;
        
        private string _isRunningParameter = "isRunning";
        private string _isAttackingParameter = "isAttacking";

        private void Awake()
        {
            _attackLayerIndex = _animator.GetLayerIndex("TopBody");
        }

        public void PlayMovementAnimation(bool isRunning)
        {
            _animator.SetBool(_isRunningParameter, isRunning);
        }
        
        public void PlayAttackAnimation(bool isAttacking)
        {
            _animator.SetBool(_isAttackingParameter, isAttacking);
            
            _animator.SetLayerWeight(_attackLayerIndex, WeightFromBool(isAttacking));
        }

        private int WeightFromBool(bool state)
        {
            if (state)
                return 1;
            return 0;
        }
    }
}