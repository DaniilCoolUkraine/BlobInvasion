using System;
using BlobInvasion.Collectable;
using UnityEngine;

namespace BlobInvasion.Player
{
    public class PlayerCollector : MonoBehaviour, ICollector
    {
        public event Action<GameObject> OnCollected;
        
        private void OnCollisionEnter(Collision collision)
        {
            ICollectable collectable = collision.gameObject.GetComponent<ICollectable>();

            if (collectable is null)
                return;
            
            Collect(collision.gameObject);
        }

        public void Collect(GameObject collectableGameObject)
        {
            ICollectable collectable = collectableGameObject.GetComponent<ICollectable>();
            
            collectable.Collect(this.gameObject);
            
            OnCollected?.Invoke(collectableGameObject);
        }
    }
}