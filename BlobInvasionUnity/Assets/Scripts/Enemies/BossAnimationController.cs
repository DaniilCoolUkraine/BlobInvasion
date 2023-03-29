using UnityEngine;

namespace BlobInvasion.Enemies
{
    public class BossAnimationController : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        
        private string _isAttackingParameter = "isAttacking";
        
        public void PlayAttackAnimation(bool isAttacking)
        {
            _animator.SetBool(_isAttackingParameter, isAttacking);
        }
    }
}