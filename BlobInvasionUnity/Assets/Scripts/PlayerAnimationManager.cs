using UnityEngine;

namespace BlobInvasion
{
    public class PlayerAnimationManager : MonoBehaviour
    {
        private string _isRunning = "isRunning";

        //todo rename onMove param
        public void PlayMovementAnimation(Animator animator, bool onMove)
        {
            animator.SetBool(_isRunning, onMove);
        }
    }
}