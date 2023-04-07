using BlobInvasion.Settings;
using UnityEngine;
using UnityEngine.Animations.Rigging;

namespace BlobInvasion.Collectable.Weapons
{
    public class WeaponManager : MonoBehaviour
    {
        [SerializeField] private Transform _parentBone;
        [SerializeField] private MultiParentConstraint _parentConstraint;
        
        [SerializeField] private PlayerSettingsSO _playerSettings;
        
        [SerializeField] private Weapon _defaultWeapon;
        
        private void Start()
        {
            CreateWeapon(_playerSettings.CurrentWeapon);
        }
        
        public void CreateWeapon(Weapon weapon)
        {
            CollectWeapon collectWeapon;
            
            if (weapon != null)
            {
                collectWeapon = Instantiate(weapon, _parentConstraint.transform.position, Quaternion.identity).GetComponent<CollectWeapon>();
            }
            else
            {
                collectWeapon = Instantiate(_defaultWeapon, _parentConstraint.transform.position, Quaternion.identity).GetComponent<CollectWeapon>();
            }
            
            collectWeapon.Initialize(_parentBone, _parentConstraint);
        }
    }
}