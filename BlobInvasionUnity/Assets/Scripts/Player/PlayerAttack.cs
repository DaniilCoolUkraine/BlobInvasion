using System;
using System.Collections;
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

        private int _enemyNearCounter = 0;
        
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
        
        private void OnTriggerEnter(Collider other)
        {
            var damageable = other.GetComponent<IDamageable>();

            if (damageable == null)
            {
                return;
            }
            
            damageable.OnDie += () => StopAttack();

            IsAttacking = true;

            _enemyNearCounter++;
            
            Debug.Log($"{other.gameObject.name} entered");
        }
        
        private void OnTriggerExit(Collider other)
        {
            var damageable = other.GetComponent<IDamageable>();

            if (damageable == null)
            {
                return;
            }
            
            StopAttack();
            
            Debug.Log($"{other.gameObject.name} left");
        }

        private void StopAttack()
        {
            Debug.Log($"{_enemyNearCounter} enemies left");
            
            _enemyNearCounter = (_enemyNearCounter - 1 < 0) ? 0 :  _enemyNearCounter - 1;
            if (_enemyNearCounter == 0)
            {
                IsAttacking = false;
            }
        }

        public void SetWeapon(Weapon weapon)
        {
            _weapon = weapon;
            _attackZone.radius = _weapon.AttackZoneRadius;
        }
    }
}