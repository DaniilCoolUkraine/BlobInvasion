using System;
using UnityEngine;

namespace BlobInvasion.ScriptableObjects
{
    [CreateAssetMenu(fileName = "ScriptableObjectEvent", menuName = "ScriptableObjects/Events/ScriptableObjectEvent")]
    public class ScriptableObjectEvent : ScriptableObject
    {
        public event Action OnInvoked;

        public void Invoke()
        {
            OnInvoked?.Invoke();        
        }
    }
}