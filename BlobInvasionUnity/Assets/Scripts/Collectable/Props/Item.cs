using System;
using UnityEngine;

namespace BlobInvasion.Collectable.Props
{
    public abstract class Item : MonoBehaviour, ICollectable
    {
        public event Action<bool> OnCollected;
        
        private bool _isColected = false;
        public bool IsCollected
        {
            get => _isColected;
            set
            {
                _isColected = value;
                OnCollected?.Invoke(_isColected);
            }
        }

        public virtual void Collect(GameObject collector)
        {
            IsCollected = true;
            Destroy(gameObject);
        }
    }
}