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
            if (collision.gameObject.CompareTag("Player"))
            {
                transform.SetParent(_parentBone);
                transform.localPosition = Vector3.zero;
                transform.localRotation = Quaternion.identity;
                _parentConstraint.weight = 1;
            }
        }
    }
}