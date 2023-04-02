using System.Reflection;
using UnityEngine;

namespace ScriptableObjectArchitecture.GameEvents.Editor
{
    public abstract class GameEventInspectorBase : UnityEditor.Editor
    {
        private FieldInfo _subscriptionsDictionaryField;
        private Vector2 scrollPos;

        protected abstract FieldInfo GetSubscriptionDictionaryFieldInfo();
        
        private void OnEnable()
        {
            _subscriptionsDictionaryField = GetSubscriptionDictionaryFieldInfo();
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            DrawPropertiesExcluding(serializedObject, new string[]{"m_Script"});
            serializedObject.ApplyModifiedProperties();
            
            if (!Application.isPlaying)
            {
                return;
            }
            GUILayout.Space(20);
            GUILayout.Label("Subscriptions Dictionary:");
            
            object subscriptionsDictionaryValue = _subscriptionsDictionaryField.GetValue(target);
            
            scrollPos = GUILayout.BeginScrollView(scrollPos);
            GUILayout.Label(subscriptionsDictionaryValue?.ToString() ?? "null");
            GUILayout.EndScrollView();
        }
    }
}