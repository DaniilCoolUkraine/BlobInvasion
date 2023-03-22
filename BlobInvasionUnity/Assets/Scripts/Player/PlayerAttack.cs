using System;
using BlobInvasion.Collectable.Props.Bonuses;
using BlobInvasion.Collectable.Weapons;
using BlobInvasion.Damageable;
using UnityEngine;

namespace BlobInvasion.Player
{
    public class PlayerAttack : MonoBehaviour, IPowerable
    {
        public event Action<bool> OnAttack;
        public bool IsActive { get; set; }

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
        
        public void Apply(params object[] param)
        {
            if (param == null || param.Length == 0 || !(param[0] is float))
            {
                return;
            }
            
            _weapon.ApplyDamageUp((int) param[0]);
        }

        public void Discard(params object[] param)
        {
            if (param == null || param.Length == 0 || !(param[0] is float))
            {
                return;
            }
            
            _weapon.ApplyDamageUp(-(int) param[0]);
        }
    }
}