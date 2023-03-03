using System;
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

        /* todo add check if enemy is near
            start coroutine onTriggerEnter, 
            stop coroutine onTriggerStay (if no enemy in trigger left)
         */
        private void OnTriggerEnter(Collider other)
        {
            var _damageble = other.GetComponent<IDamageable>();
            if (_damageble != null)
                Attack();
        }
        
        public void SetWeapon(Weapon weapon)
        {
            _weapon = weapon;
            _attackZone.radius = _weapon.AttackZoneRadius;
        }
        
        // starts animation
        private void Attack()
        {
            OnAttack?.Invoke(true);
        }
    }
}