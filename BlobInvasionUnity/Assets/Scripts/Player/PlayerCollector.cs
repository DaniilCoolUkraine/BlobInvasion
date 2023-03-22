﻿using System;
using BlobInvasion.Collectable;
using BlobInvasion.Collectable.Props.Bonuses;
using UnityEngine;

namespace BlobInvasion.Player
{
    public class PlayerCollector : MonoBehaviour, ICollector, IPowerable
    {
        public event Action<GameObject> OnCollected;
        public bool IsActive { get; set; }
        
        [SerializeField] private SphereCollider _collider;
        
        private void OnTriggerEnter(Collider other)
        {
            ICollectable collectable = other.gameObject.GetComponent<ICollectable>();

            if (collectable is null)
                return;
            
            Collect(other.gameObject);
        }

        public void Collect(GameObject collectableGameObject)
        {
            ICollectable collectable = collectableGameObject.GetComponent<ICollectable>();
            
            collectable.Collect(this.gameObject);
            
            OnCollected?.Invoke(collectableGameObject);
        }

        public void Apply(params object[] param)
        {
            if (param == null || param.Length == 0 || !(param[0] is float))
            {
                return;
            }

            _collider.radius = (float) param[0];
            IsActive = true;
        }

        public void Discard(params object[] param)
        {
            if (param == null || param.Length == 0 || !(param[0] is float))
            {
                return;
            }
            
            _collider.radius = (float) param[0];
            IsActive = false;
        }
    }
}