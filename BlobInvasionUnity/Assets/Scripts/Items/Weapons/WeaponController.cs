using UnityEngine;

namespace BlobInvasion.Items.Weapons
{
    public class WeaponController : MonoBehaviour
    {
        [SerializeField] private AttackWeaponDetector _attackWeaponDetector;
        [SerializeField] private Weapon _weapon;

        private void OnEnable()
        {
            _attackWeaponDetector.OnWeaponTriggered += _weapon.Attack;
        }

        private void OnDisable()
        {
            _attackWeaponDetector.OnWeaponTriggered -= _weapon.Attack;
        }
    }
}