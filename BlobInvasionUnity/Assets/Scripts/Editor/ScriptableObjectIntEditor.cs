using UnityEditor;
using UnityEngine;

namespace BlobInvasion
{
    [CustomEditor(typeof(ScriptableObjectInt))]
    public class ScriptableObjectIntEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            ScriptableObjectInt scriptableObjectInt = (ScriptableObjectInt)target;

            if (GUILayout.Button("Clear"))
            {
                scriptableObjectInt.Value.ChangeValue(0);
            }
            else if(GUILayout.Button("Update"))
            {
                scriptableObjectInt.Value.ChangeValue(scriptableObjectInt.Value.Value);
            }

            EditorUtility.SetDirty(scriptableObjectInt);
        }
    }
}