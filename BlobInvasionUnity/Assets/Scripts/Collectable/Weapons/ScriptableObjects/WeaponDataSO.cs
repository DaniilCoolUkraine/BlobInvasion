using UnityEngine;

namespace BlobInvasion.Collectable.Weapons.ScriptableObjects
{
    [CreateAssetMenu(fileName = "NewWeapon", menuName = "WeaponData", order = 0)]
    public class WeaponDataSO : ScriptableObject
    {
        //todo add "additional damage" system (have no idea)

        [SerializeField] private int _damage;
        [SerializeField] private float _attackSpeed;
        [SerializeField] private float _attackRadius;

        public int Damage => _damage;
        public float AttackSpeed => _attackSpeed;
        public float AttackRadius => _attackRadius;
    }
}