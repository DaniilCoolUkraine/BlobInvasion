using UnityEngine;

namespace BlobInvasion.Enemies
{
    [CreateAssetMenu(fileName = "NewEnemyMarket", menuName = "EnemyMarket", order = 1)]
    public class EnemyMarket : ScriptableObject
    {
        [SerializeField] private EnemyDataSO[] _enemies;
        public EnemyDataSO[] Enemies => _enemies;

        public EnemyDataSO GetEnemy(int index)
        {
            if (index < 0)
                return null;
            if (index >= _enemies.Length)
                return null;

            return _enemies[index];
        }
    }
}