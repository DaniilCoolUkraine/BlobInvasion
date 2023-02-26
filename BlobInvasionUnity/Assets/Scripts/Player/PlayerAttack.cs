using System;
using BlobInvasion.Items.Weapons;
using UnityEngine;

namespace BlobInvasion.Player
{
    public class PlayerAttack : MonoBehaviour
    {
        public event Action<bool> OnAttack;

        [SerializeField] private CollisionDetectorEnemy _collisionDetector;

        private Weapon _weapon;
        private int _additionalDamage;

        //todo Attack should start not on click
        //todo Attack should start on enemy enter player trigger zone
        //todo attack should be automatic
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
                Attack();
        }

        public void SetWeapon(Weapon weapon)
        {
            _weapon = weapon;
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