using System.Reflection;
using ScriptableObjectArchitecture.Base;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace ScriptableObjectArchitecture.Editor
{
    [CustomEditor(typeof(ScriptableObjectArchitectureObject), true)]
    public class ScriptableObjectArchitectureObjectEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            DrawDebugButton();
            DrawPropertiesExcluding(serializedObject, new []{"m_Script", "<DebugMode>k__BackingField"});
            serializedObject.ApplyModifiedProperties();
        }

        private void DrawDebugButton()
        {
            if (target is not ScriptableObjectArchitectureObject soArchObject)
            {
                return;
            }

            FieldInfo fieldInfo = typeof(ScriptableObjectArchitectureObject).GetField("<DebugMode>k__BackingField",
                BindingFlags.Instance | BindingFlags.NonPublic);
            if (fieldInfo is null)
            {
                GUILayout.Label("Cannot find the DebugMode field info", new GUIStyle(GUI.skin.button){normal = {textColor = Color.red}});
                return;
            }

            bool debugMode = (bool)fieldInfo.GetValue(soArchObject);
            
            GUIStyle style = debugMode
                ? new GUIStyle(GUI.skin.button){normal = {textColor = Color.red}, hover = {textColor = Color.red}}
                : GUI.skin.button;
            string buttonLabel = "Debug Mode " + (debugMode ? "ON" : "OFF");
            if (GUILayout.Button(buttonLabel, style))
            {
                fieldInfo.SetValue(soArchObject, !debugMode);
            }
        }
    }
}