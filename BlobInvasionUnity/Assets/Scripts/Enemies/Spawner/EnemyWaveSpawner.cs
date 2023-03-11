using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlobInvasion.Enemies.Spawner
{
    public class EnemyWaveSpawner : MonoBehaviour
    {
        public List<EnemyDataSO> EnemiesToSpawn { get; private set; } 
        
        [SerializeField] private EnemyMarket _enemyMarket;

        [Min(1)] [SerializeField] private int _waveWeightCoefficient;
        [Min(10)] [SerializeField] private float _timeBetweenWaves = 10;
        [Min(0.1f)] [SerializeField] private float _timeBetweenSpawn = 1;
        
        private int _currentWave = 1;
        private int _waveWeight;

        private bool _isWavesCreatingNeed = true;

        private void Awake()
        {
            EnemiesToSpawn = new List<EnemyDataSO>();
        }

        private void Start()
        {
            StartCoroutine(GenerateWave());
        }

        public IEnumerator GenerateWave()
        {
            while (_isWavesCreatingNeed)
            {
                _waveWeight = _currentWave * _waveWeightCoefficient;
                EnemiesToSpawn.Clear();

                GenerateEnemies();
                //todo replace to "yield return StartCoroutine(CreateEnemiesOnScene());"
                //it will be wait untill CreateEnemiesOnScene() coroutine is completed
                
                StartCoroutine(CreateEnemiesOnScene());
                yield return new WaitForSeconds(_timeBetweenWaves);
            }
        }

        private void GenerateEnemies()
        {
            while (_waveWeight > 0)
            {
                EnemyDataSO randomEnemy = _enemyMarket.Enemies[Random.Range(0, _enemyMarket.Enemies.Length)];
                
                if (randomEnemy.EnemyWeight > _waveWeight)
                    continue;
                
                EnemiesToSpawn.Add(randomEnemy);
                _waveWeight -= randomEnemy.EnemyWeight;
            }
        }

        private IEnumerator CreateEnemiesOnScene()
        {
            foreach (EnemyDataSO enemy in EnemiesToSpawn)
            {
                yield return new WaitForSeconds(_timeBetweenSpawn);
                Instantiate(enemy.EnemyPrefab);
            }
        }
    }
}