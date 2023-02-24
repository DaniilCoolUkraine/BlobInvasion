﻿using UnityEngine;

namespace BlobInvasion
{
    public class PlayerAnimationController : MonoBehaviour
    {
        private string _isRunningParameter = "isRunning";
        
        public void PlayMovementAnimation(Animator animator, bool isRunning)
        {
            animator.SetBool(_isRunningParameter, isRunning);
        }
    }
}