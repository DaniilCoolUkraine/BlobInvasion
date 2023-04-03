using UnityEngine;

namespace BlobInvasion.Enemies.Spawner
{
    public class BossSpawner : MonoBehaviour
    {
        [SerializeField] private Transform _playerTransform;
        [SerializeField] private GameObject _bossPrefab;
        
        private void OnEnable()
        {
            EnemyMovement bossMove = Instantiate(_bossPrefab).GetComponent<EnemyMovement>();
            bossMove.Initialize(_playerTransform);
        }
    }
}