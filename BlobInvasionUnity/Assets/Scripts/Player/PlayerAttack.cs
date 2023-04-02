using System;
using BlobInvasion.Collectable.Props.Bonuses;
using BlobInvasion.Collectable.Weapons;
using BlobInvasion.Damageable;
using BlobInvasion.Unlocker;
using UnityEngine;

namespace BlobInvasion.Player
{
    public class PlayerAttack : MonoBehaviour, IPowerable, IUnlocker
    {
        public event Action<bool> OnAttack;
        public event Action OnGoalReached;

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
        
        private int _enemyKilled = 0;
        private int EnemyKilled
        {
            get => _enemyKilled;
            set
            {
                _enemyKilled = value;
                if (_enemyKilled >= 30)
                {
                    OnGoalReached?.Invoke();
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            var damageable = other.GetComponent<IDamageable>();

            if (damageable == null)
            {
                return;
            }
            
            damageable.OnHealthIsZero += () =>
            {
                StopAttack();
                EnemyKilled += 1;
            };

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

        public void SetWeapon(Weapon weapon)
        {
            _weapon = weapon;
            _attackZone.radius = _weapon.AttackZoneRadius;
        }

        public void ApplyPowerUp(params object[] param)
        {
            _weapon.ApplyDamageUp((int) param[0]);
        }
        
        public void DoUnlock(GameObject unlockable)
        {
            SetWeapon(unlockable.GetComponent<Weapon>());
        }
        
        private void StopAttack()
        {
            _enemyNearCounter = (_enemyNearCounter - 1 < 0) ? 0 :  _enemyNearCounter - 1;
            if (_enemyNearCounter == 0)
            {
                IsAttacking = false;
            }
        }
    }
}