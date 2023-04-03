using System;
using UnityEngine;

namespace BlobInvasion.ScriptableObjects
{
    [CreateAssetMenu(fileName = "ScriptableObjectBoolEvent", menuName = "ScriptableObject/Events/ScriptableObjectBoolEvent")]
    public class ScriptableObjectBoolEvent : ScriptableObject
    {
        public event Action<bool> OnValueChanged;

        public void ChangeValue(bool value)
        {
            OnValueChanged?.Invoke(value);        
        }
    }
}