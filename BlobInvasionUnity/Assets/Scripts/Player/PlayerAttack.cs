using System;
using BlobInvasion.Collectable.Weapons;
using BlobInvasion.Damageable;
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
        }
        
        private void OnTriggerExit(Collider other)
        {
            var damageable = other.GetComponent<IDamageable>();

            if (damageable == null)
            {
                return;
            }
            
            StopAttack();
        }

        private void StopAttack()
        {
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