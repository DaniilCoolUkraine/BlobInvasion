using BlobInvasion.Player;
using UnityEngine;
using UnityEngine.Animations.Rigging;

namespace BlobInvasion.Items.Weapons
{
    public class PickUpWeaponDetector : MonoBehaviour
    {
        [SerializeField] private Weapon _weapon;
        
        // todo cannot be set in prefab (not sure how to fix)
        [SerializeField] private Transform _parentBone;
        [SerializeField] private MultiParentConstraint _parentConstraint;

        [SerializeField] private Collider _weaponCollider;
        [SerializeField] private Collider _weaponTrigger;

        private void OnCollisionEnter(Collision collision)
        {
            // todo move "Player" to separate Constant class in separate file (ask about it)
            if (collision.gameObject.CompareTag("Player"))
            {
                ParentToAnimation();
                collision.transform.GetComponent<PlayerController>().PlayerAttack.SetWeapon(_weapon);
            }
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