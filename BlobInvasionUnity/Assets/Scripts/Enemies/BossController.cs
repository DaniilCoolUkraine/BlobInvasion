using UnityEngine;

namespace BlobInvasion.Enemies
{
    public class BossController : MonoBehaviour
    {
        [SerializeField] private BossTriggerDetector _triggerDetector;
        [SerializeField] private BossAnimationController _animationController;

        private void OnEnable()
        {
            _triggerDetector.OnTriggered += _animationController.PlayAttackAnimation;
        }
        private void OnDisable()
        {
            _triggerDetector.OnTriggered -= _animationController.PlayAttackAnimation;
        }
    }
}