using System;
using BlobInvasion.Player;
using UnityEngine;
using UnityEngine.Animations.Rigging;

namespace BlobInvasion.Collectable.Weapons
{
    public class CollectWeapon : MonoBehaviour, ICollectable
    {
        public event Action<bool> OnCollected;
        
        [SerializeField] private Weapon _weapon;
        
        [SerializeField] private Collider _weaponCollider;
        [SerializeField] private Collider _weaponTrigger;
        
        private Transform _parentBone;
        private MultiParentConstraint _parentConstraint;

        private bool _isColected = false;
        public bool IsCollected
        {
            get => _isColected;
            set
            {
                _isColected = value;
                OnCollected?.Invoke(_isColected);
            }
        }

        public void Initialize(Transform parentBone, MultiParentConstraint parentConstraint)
        {
            _parentBone = parentBone;
            _parentConstraint = parentConstraint;
        }
        
        public void Collect(GameObject collector)
        {
            IsCollected = true;

            ParentToAnimation();
            collector.transform.GetComponent<PlayerController>().PlayerAttack.SetWeapon(_weapon);
        }
        
        private void ParentToAnimation()
        {
            transform.SetParent(_parentBone);
            _parentConstraint.weight = 1;
            
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;

            _weaponCollider.enabled = false;
            _weaponTrigger.enabled = true;
        }
    }
}