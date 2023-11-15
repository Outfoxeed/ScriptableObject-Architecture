using System.Linq;
using ScriptableObjectArchitecture.Editor;
using UnityEditor;
using UnityEngine;

namespace ScriptableObjectArchitecture.GameEvents.Editor.GameEvents
{
    [CustomEditor(typeof(GameEvent<>), true)]
    public class GameEventEditor : ScriptableObjectArchitectureObjectEditor
    {
        private const string DebugRaiseParameterName = "_debugRaiseParameter";
        private object _debugRaiseParameter;

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (!Application.isPlaying)
            {
                return;
            }

            if (target is not IGameEvent gameEvent)
            {
                return;
            }

            EditorGUILayout.Space(15);

            serializedObject.Update();
            DrawDebugParameterField();
            serializedObject.ApplyModifiedProperties();
            if (GUILayout.Button("Debug Raise"))
            {
                gameEvent.RaiseWithDebugParameter();
            }
        }

        private void DrawDebugParameterField()
        {
            SerializedProperty sp = serializedObject.FindProperty(DebugRaiseParameterName);
            if (sp is null)
            {
                string errorMsg = $"Cannot find SerializedProperty of name '{DebugRaiseParameterName}'. Value's type might not be serializable";
                EditorGUILayout.LabelField(errorMsg, new GUIStyle(GUI.skin.label) {fontStyle = FontStyle.Italic, fontSize = 9});
                return;
            }
            
            // TODO: This does not accept scene references (non prefab GameObject, MonoBehaviours, etc...)
            EditorGUILayout.PropertyField(sp);
        }

        protected override string[] GetPropertiesToExclude() 
            => base.GetPropertiesToExclude().Append(DebugRaiseParameterName).ToArray();
    }
}