using System;
using BlobInvasion.Damageable;
using UnityEngine;

namespace BlobInvasion.Items.Weapons
{
    public class AttackWeaponDetector : MonoBehaviour
    {
        public event Action<IDamageable> OnWeaponTriggered;
        private void OnTriggerEnter(Collider other)
        {
            var _damageble = other.GetComponent<IDamageable>();
            if (_damageble != null)
            {
                OnWeaponTriggered?.Invoke(_damageble);
            }
        }
    }
}