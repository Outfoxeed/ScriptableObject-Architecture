using ScriptableObjectArchitecture.Base;
using ScriptableObjectArchitecture.Variables;
using UnityEditor;
using UnityEngine;
using Logger = ScriptableObjectArchitecture.Utils.Logger;

namespace ScriptableObjectArchitecture.Editor.Editor.Variables
{
    [CustomEditor(typeof(Variable<>), true)]
    public class VariableEditor : ScriptableObjectArchitectureObjectEditor
    {
        private const string PropertyName = "_property";
        
        public override void OnInspectorGUI()
        {
            SerializedProperty spProperty = serializedObject.FindProperty(PropertyName);
            if (spProperty is null)
            {
                string errorMsg = $"Cannot find SerializedProperty of name '{PropertyName}'";
                GUILayout.Label(errorMsg);
                Logger.Instance?.Log(target as ScriptableObjectArchitectureObject, Logger.LogType.Error, errorMsg);
            }

            spProperty.isExpanded = true;
            
            base.OnInspectorGUI();
        }
    }
}