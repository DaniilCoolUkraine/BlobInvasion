using System.Collections.Generic;
using BlobInvasion.Collectable;
using UnityEngine;

namespace BlobInvasion.Player
{
    public class PlayerCollector : MonoBehaviour, ICollector
    {
        private List<ICollectable> _collectables = new List<ICollectable>();

        private void OnCollisionEnter(Collision collision)
        {
            ICollectable collectable = collision.gameObject.GetComponent<ICollectable>();

            if (collectable is null)
                return;
            
            Collect(collectable);
        }

        public void Collect(ICollectable collectable)
        {
            collectable.Collect(this.gameObject);
            _collectables.Add(collectable);
        }
    }
}