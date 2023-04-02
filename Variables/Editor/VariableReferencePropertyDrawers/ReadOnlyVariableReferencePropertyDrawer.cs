using UnityEditor;
using UnityEngine;

namespace ScriptableObjectArchitecture.Variables.Editor
{
    [CustomPropertyDrawer(typeof(ReadOnlyVariableReference<>))]
    public class ReadOnlyVariableReferencePropertyDrawer : VariableReferencePropertyDrawerBase
    {
        protected override string VariablePropertyName => "_readOnlyVariable";

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            base.OnGUI(position, property, label);
        }
    }
}