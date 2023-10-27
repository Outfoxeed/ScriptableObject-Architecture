using UnityEditor;

namespace ScriptableObjectArchitecture.GameEvents.Editor.GameEvents.Editor
{
    [CustomEditor(typeof(GameEvent<>), true)]
    public class GameEventInspector : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            DrawPropertiesExcluding(serializedObject, new string[]{"m_Script"});
            serializedObject.ApplyModifiedProperties();
        }
    }
}