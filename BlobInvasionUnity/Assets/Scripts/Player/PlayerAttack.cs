using System;
using BlobInvasion.Items.Weapons;
using UnityEngine;

namespace BlobInvasion.Player
{
    public class PlayerAttack : MonoBehaviour
    {
        public event Action<bool> OnAttack;

        [SerializeField] private SphereCollider _attackZone;
       
        private Weapon _weapon;
        private int _additionalDamage;
        
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
                Attack();
        }

        public void SetWeapon(Weapon weapon)
        {
            _weapon = weapon;
            _attackZone.radius = _weapon.AttackZoneRadius;
        }

        public void SetAdditionalDamage(int additionalDamage)
        {
            _additionalDamage = additionalDamage;
        }

        private void Attack()
        {
            //todo here we should call something like _weapon.Attack(additionalDamage);
            OnAttack?.Invoke(true);
        }
    }
}