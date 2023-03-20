using UnityEngine;

namespace BlobInvasion.Collectable.Weapons.ScriptableObjects
{
    [CreateAssetMenu(fileName = "NewWeapon", menuName = "WeaponData", order = 0)]
    public class WeaponDataSO : ScriptableObject
    {
        [SerializeField] private int _damage;
        [SerializeField] private int _additionalDamage;
        
        [SerializeField] private float _attackRadius;

        public int Damage => _damage;
        public int AdditionalDamage => _additionalDamage;
        
        public float AttackRadius => _attackRadius;
        
        public void AddDamage(int additionalDamage)
        {
            Debug.Log(additionalDamage);
            _additionalDamage += additionalDamage;
        }
    }
}