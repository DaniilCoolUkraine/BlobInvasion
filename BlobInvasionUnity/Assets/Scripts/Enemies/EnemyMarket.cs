using UnityEngine;

namespace BlobInvasion
{
    [CreateAssetMenu(fileName = "NewEnemyMarket", menuName = "EnemyMarket", order = 1)]
    public class EnemyMarket : ScriptableObject
    {
        [SerializeField] private EnemyDataSO[] _enemies;
        public EnemyDataSO[] Enemies => _enemies;
    }
}