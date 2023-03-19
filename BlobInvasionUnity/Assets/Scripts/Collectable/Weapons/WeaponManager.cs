using UnityEngine;
using UnityEngine.Animations.Rigging;

namespace BlobInvasion.Collectable.Weapons
{
    public class WeaponManager : MonoBehaviour
    {
        [SerializeField] private Transform _parentBone;
        [SerializeField] private MultiParentConstraint _parentConstraint;

        // todo replace with scriptable object, like enemies
        [SerializeField] private CollectWeapon[] _weapons;

        private void Start()
        {
            CreateWeapon();
        }

        public void CreateWeapon()
        {
            CollectWeapon weapon = Instantiate(_weapons[Random.Range(0, _weapons.Length)]);
            weapon.Initialize(_parentBone, _parentConstraint);
        }
    }
}