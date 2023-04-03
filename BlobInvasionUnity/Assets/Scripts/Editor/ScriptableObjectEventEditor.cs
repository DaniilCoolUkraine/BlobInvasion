using BlobInvasion.ScriptableObjects;
using UnityEditor;
using UnityEngine;

namespace BlobInvasion
{
    [CustomEditor(typeof(ScriptableObjectEvent))]
    public class ScriptableObjectEventEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            ScriptableObjectEvent scriptableObjectEvent = (ScriptableObjectEvent)target;

            if (GUILayout.Button("Invoke"))
            {
                scriptableObjectEvent.Invoke();
            }

            EditorUtility.SetDirty(scriptableObjectEvent);
        }
    }
}