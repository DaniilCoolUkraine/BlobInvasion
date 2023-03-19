using UnityEngine;

namespace BlobInvasion.Damageable.ScriptableObjects
{
    [CreateAssetMenu(fileName = "NewHealthData", menuName = "HealthData", order = 0)]
    public class HealthData : ScriptableObject
    {
        [SerializeField] private int _maxHp;
        public int MaxHp => _maxHp;
    }
}