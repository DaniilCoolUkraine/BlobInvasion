using System;
using UnityEngine;
using UnityEngine.AI;

namespace BlobInvasion.Enemies
{
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private NavMeshAgent _agent;

        private Transform _player;

        private void Awake()
        {
            _agent.speed = _speed;
        }

        private void Update()
        {
            if (_player != null)
            {
                _agent.SetDestination(_player.position);
            }
        }
        
        public void Initialize(Transform player)
        {
            _player = player;
        }
    }
}