using UnityEngine;
using UnityEngine.Animations.Rigging;

namespace BlobInvasion.Collectable.Weapons
{
    public class WeaponManager : MonoBehaviour
    {
        [SerializeField] private Transform _parentBone;
        [SerializeField] private MultiParentConstraint _parentConstraint;
        
        public void CreateWeapon(Weapon weapon)
        {
            CollectWeapon collectWeapon = Instantiate(weapon, _parentConstraint.transform.position, Quaternion.identity).GetComponent<CollectWeapon>();
            collectWeapon.Initialize(_parentBone, _parentConstraint);
        }
    }
}