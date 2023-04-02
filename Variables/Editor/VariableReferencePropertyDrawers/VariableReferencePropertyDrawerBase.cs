using UnityEditor;
using UnityEngine;

namespace ScriptableObjectArchitecture.Variables.Editor
{
    public abstract class VariableReferencePropertyDrawerBase : PropertyDrawer
    {
        private const string USE_CUSTOM_VALUE_NAME = "_useCustomValue";
        private const string CUSTOM_VALUE_NAME = "_customValue";
        protected abstract string VariablePropertyName { get; }

        public override void OnGUI(Rect position, SerializedProperty property,
            GUIContent label)
        {
            Rect labelPosition = position;
            labelPosition.width *= 0.4f;
            EditorGUI.LabelField(labelPosition, label);
            
            Rect togglePosition = labelPosition;
            togglePosition.x += labelPosition.width;
            togglePosition.width = 20;
            SerializedProperty spUseCustomValue = property.FindPropertyRelative(USE_CUSTOM_VALUE_NAME);
            EditorGUI.PropertyField(togglePosition, spUseCustomValue, GUIContent.none);
            
            Rect valuePosition = togglePosition;
            valuePosition.x += togglePosition.width;
            valuePosition.width = position.width - labelPosition.width - togglePosition.width;
            SerializedProperty spValue = property.FindPropertyRelative(
                spUseCustomValue.boolValue ? CUSTOM_VALUE_NAME : VariablePropertyName);
            EditorGUI.PropertyField(valuePosition, spValue, GUIContent.none);
        }
    
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return base.GetPropertyHeight(property, label);
        }
    }
}