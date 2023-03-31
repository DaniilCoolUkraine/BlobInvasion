﻿using BlobInvasion.Damageable;
using UnityEngine;

namespace BlobInvasion.Enemies
{
    public class BossController : MonoBehaviour
    {
        [SerializeField] private BossTriggerDetector _triggerDetector;
        [SerializeField] private BossAnimationController _animationController;

        [SerializeField] private BossAttack _bossAttack;

        private void OnEnable()
        {
            _triggerDetector.OnTriggered += OnTriggered;
        }

        private void OnDisable()
        {
            _triggerDetector.OnTriggered -= OnTriggered;
        }

        private void OnTriggered(bool isTriggered, IDamageable damageable)
        {
            _animationController.PlayAttackAnimation(isTriggered);
            _bossAttack.SetDamageable(damageable);
        }
    }
}