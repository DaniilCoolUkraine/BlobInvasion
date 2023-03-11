using UnityEngine;

namespace BlobInvasion.Enemies
{
    public class EnemyMovement : MonoBehaviour
    {
        //todo cannot be set in prefab (ask about it) 
        //[SerializeField] private Transform _player;

        [SerializeField] private float _speed;

        private static Transform _player;

        private void Start()
        {
            if (_player == null)
            {
                Debug.Log("a");
                _player = GameObject.FindWithTag("Player").transform;
            }
        }

        private void FixedUpdate()
        {
            transform.position =
                Vector3.MoveTowards(transform.position, _player.position, _speed * Time.fixedDeltaTime);
            transform.LookAt(_player);
        }
    }
}