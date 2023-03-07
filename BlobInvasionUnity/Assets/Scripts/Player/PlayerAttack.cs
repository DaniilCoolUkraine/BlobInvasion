using System;
using System.Collections;
using System.Collections.Generic;
using BlobInvasion.Damageable;
using BlobInvasion.Items.Weapons;
using UnityEngine;

namespace BlobInvasion.Player
{
    public class PlayerAttack : MonoBehaviour
    {
        public event Action<bool> OnAttack;

        [SerializeField] private SphereCollider _attackZone;
       
        private Weapon _weapon;

        private bool _isAttacking;
        public bool IsAttacking
        {
            get => _isAttacking;
            set
            {
                _isAttacking = value;
                OnAttack?.Invoke(_isAttacking);
            }
        }

        private bool _isEnemyNear;
        
        private void OnTriggerStay(Collider other)
        {
            // todo to heavy getting component each frame
            // use some methods to remember enemies, that have been checked
            var damageable = other.GetComponent<IDamageable>();
            if (damageable == null)
            {
                _isEnemyNear = false;
                return;
            }

            _isEnemyNear = true;
            StartCoroutine(Attack());
        }
        
        public void SetWeapon(Weapon weapon)
        {
            _weapon = weapon;
            _attackZone.radius = _weapon.AttackZoneRadius;
        }
        
        // starts animation
        private IEnumerator Attack()
        {
            while (_isEnemyNear)
            {
                IsAttacking = true;
                yield return new WaitForSeconds(_weapon.AttackCooldown);
                IsAttacking = false;
            }
        }
    }
}