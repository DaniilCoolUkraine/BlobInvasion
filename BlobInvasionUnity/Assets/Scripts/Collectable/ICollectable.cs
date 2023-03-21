using System;
using BlobInvasion.Collectable.Props.Bonuses.ScriptableObjects;
using UnityEngine;

namespace BlobInvasion.Collectable
{
    public interface ICollectable
    {
        event Action<bool> OnCollected;
      
        bool IsCollected { get; set; }

        public void Collect(GameObject collector);
    }
}