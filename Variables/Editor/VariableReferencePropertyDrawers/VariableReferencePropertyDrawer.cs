using UnityEditor;
using UnityEngine;

namespace ScriptableObjectArchitecture.Variables.Editor
{
    [CustomPropertyDrawer(typeof(VariableReference<>), true)]
    public class VariableReferencePropertyDrawer : VariableReferencePropertyDrawerBase
    {
        protected override string VariablePropertyName => "_variable";

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            base.OnGUI(position, property, label);
        }
    }
}