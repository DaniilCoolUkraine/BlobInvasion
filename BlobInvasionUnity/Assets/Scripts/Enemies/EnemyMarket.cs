using UnityEngine;

namespace BlobInvasion.Enemies
{
    [CreateAssetMenu(fileName = "NewEnemyMarket", menuName = "EnemyMarket", order = 1)]
    public class EnemyMarket : ScriptableObject
    {
        [SerializeField] private EnemyDataSO[] _enemies;
        //todo add method "EnemyDataSO GetEnemy(int index)" to return specific enemy by index
        //add check of index > 0 && index < _enemies.Lenght
        public EnemyDataSO[] Enemies => _enemies;
    }
}