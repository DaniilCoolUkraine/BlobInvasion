using System;
using BlobInvasion.Damageable;
using UnityEngine;

namespace BlobInvasion.Collectable.Weapons
{
    public class AttackWeaponDetector : MonoBehaviour
    {
        public event Action<IDamageable> OnWeaponTriggered;
        private void OnTriggerEnter(Collider other)
        {
            var damageable = other.GetComponent<IDamageable>();
            if (damageable != null)
            {
                OnWeaponTriggered?.Invoke(damageable);
            }
        }
    }
}