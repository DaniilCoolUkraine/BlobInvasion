using BlobInvasion.Player;
using UnityEngine;
using UnityEngine.Animations.Rigging;

namespace BlobInvasion.Items.Weapons
{
    public class PickUpWeaponDetector : MonoBehaviour
    {
        [SerializeField] private Transform _parentBone;
        [SerializeField] private MultiParentConstraint _parentConstraint;
        
        private void OnCollisionEnter(Collision collision)
        {
            //move "Player" to separate Constant class in separate file
            if (collision.gameObject.CompareTag("Player"))
            {
                ParentToAnimation();
                collision.gameObject.GetComponent<PlayerAttack>().SetWeapon(this.GetComponent<Weapon>());
            }
        }

        private void ParentToAnimation()
        {
            transform.SetParent(_parentBone);
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            _parentConstraint.weight = 1;
        }
    }
}