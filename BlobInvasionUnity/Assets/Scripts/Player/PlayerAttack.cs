using System;
using BlobInvasion.Items.Weapons;
using UnityEngine;

namespace BlobInvasion.Player
{
    public class PlayerAttack : MonoBehaviour
    {
        public event Action<bool> OnAttack;

        [SerializeField] private CollisionDetector _collisionDetector;

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
        }

        public void SetAdditionalDamage(int additionalDamage)
        {
            _additionalDamage = additionalDamage;
        }
        
        private void Attack()
        {
            OnAttack?.Invoke(true);
        }
    }
}