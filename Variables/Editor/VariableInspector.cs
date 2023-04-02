using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace ScriptableObjectArchitecture.Variables.Editor
{
    [CustomEditor(typeof(Variable<>), true)]
    public class VariableInspector : UnityEditor.Editor
    {
        private const string _subscriptionsDictionaryName = "_subscriptions";
        private FieldInfo _subscriptionsDictionaryField;
        private Vector2 scrollPos;
        
        private void OnEnable()
        {
            _subscriptionsDictionaryField = target.GetType().BaseType.GetField(_subscriptionsDictionaryName,
                BindingFlags.Instance | BindingFlags.NonPublic);
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            DrawPropertiesExcluding(serializedObject, new []{"m_Script"});
            serializedObject.ApplyModifiedProperties();

            if (!Application.isPlaying)
            {
                return;
            }
            GUILayout.Space(20);
            GUILayout.Label("Subscriptions Dictionary:");
            
            object subscriptionsDictionaryValue = _subscriptionsDictionaryField.GetValue(target);
            
            scrollPos = GUILayout.BeginScrollView(scrollPos);
            GUILayout.Label(subscriptionsDictionaryValue.ToString());
            GUILayout.EndScrollView();
        }
    }
}