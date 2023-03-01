using UnityEngine;

namespace BlobInvasion
{
    [CreateAssetMenu(fileName = "NewEnemyData", menuName = "EnemyData", order = 0)]
    public class EnemyDataSO : ScriptableObject
    {
        [SerializeField] private GameObject _enemyPrefab;
        [SerializeField] private int _enemyWeight;

        public GameObject EnemyPrefab => _enemyPrefab;
        public int EnemyWeight => _enemyWeight;
    }
}