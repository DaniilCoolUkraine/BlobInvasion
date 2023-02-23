using UnityEngine;

namespace BlobInvasion
{
    public class PlayerAnimationManager : MonoBehaviour
    {
        //todo rename to _isRunnigParametr
        private string _isRunning = "isRunning";

        //todo rename onMove param isMoving
        public void PlayMovementAnimation(Animator animator, bool onMove)
        {
            animator.SetBool(_isRunning, onMove);
        }
    }
}