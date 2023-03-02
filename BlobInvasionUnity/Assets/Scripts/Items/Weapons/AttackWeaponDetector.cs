using System;
using UnityEngine;

namespace BlobInvasion
{
    public class AttackWeaponDetector : MonoBehaviour
    {
        public event Action<bool> OnDetectEnemy;

        private bool _isEnemyNear = false;
        public bool IsEnemyNear
        {
            get => _isEnemyNear;
            set
            {
                _isEnemyNear = value;
                OnDetectEnemy?.Invoke(_isEnemyNear);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            //need to add check on enemy tag
            _isEnemyNear = true;
            //start coroutine
        }

        private void OnTriggerStay(Collider other)
        {
            /*
            var enemy = other.GetComponent<Enemy>();

            if(enemy == null)
            {
                _isEnemyNear = false;
                return;
            }

            _isEnemyNear = true;
            */
            //is any enemy stay
        }
    }
}