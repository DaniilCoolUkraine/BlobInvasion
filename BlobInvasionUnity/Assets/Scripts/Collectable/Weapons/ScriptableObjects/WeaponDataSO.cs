using UnityEngine;

namespace BlobInvasion.Collectable.Weapons.ScriptableObjects
{
    [CreateAssetMenu(fileName = "NewWeapon", menuName = "ScriptableObjects/WeaponData", order = 0)]
    public class WeaponDataSO : ScriptableObject
    {
        [SerializeField] private int _damage;
        [SerializeField] private int _additionalDamage;
        
        [SerializeField] private float _attackRadius;

        [SerializeField] private string _name;

        public int Damage => _damage;
        public int AdditionalDamage => _additionalDamage;
        
        public float AttackRadius => _attackRadius;

        public string Name => _name;
        
        public void AddDamage(int additionalDamage)
        {
            _additionalDamage += additionalDamage;
        }
    }
}