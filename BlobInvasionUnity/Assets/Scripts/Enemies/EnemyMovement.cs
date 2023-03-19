using UnityEngine;

namespace BlobInvasion.Enemies
{
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private Transform _player;
        
        private void Update()
        {
            if (_player != null)
            {
                transform.position =
                    Vector3.MoveTowards(transform.position, _player.position, _speed * Time.deltaTime);
                
                transform.LookAt(_player);
            }
        }
        
        public void Initialize(Transform player)
        {
            _player = player;
        }
    }
}