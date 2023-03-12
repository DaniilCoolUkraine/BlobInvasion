using UnityEngine;

namespace BlobInvasion.Enemies
{
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private Transform _player;

        public void Initialize(Transform player)
        {
            _player = player;
        }

        //todo replace to Update or use Rigidbody
        private void FixedUpdate()
        {
            if (_player != null)
            {
                transform.position =
                    Vector3.MoveTowards(transform.position, _player.position, _speed * Time.fixedDeltaTime);
                transform.LookAt(_player);
            }
        }
    }
}