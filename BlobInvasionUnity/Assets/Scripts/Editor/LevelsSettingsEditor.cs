using BlobInvasion.Settings;
using UnityEditor;
using UnityEngine;

namespace BlobInvasion
{
    [CustomEditor(typeof(LevelSettingsSO))]
    public class LevelsSettingsEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            LevelSettingsSO levelSettings = (LevelSettingsSO)target;

            if (GUILayout.Button("Clear"))
            {
                levelSettings.SetScene(string.Empty);
            }
            else if(GUILayout.Button("Update"))
            {
                levelSettings.SetScene(levelSettings.CurrentScene);
            }

            EditorUtility.SetDirty(levelSettings);
        }
    }
}