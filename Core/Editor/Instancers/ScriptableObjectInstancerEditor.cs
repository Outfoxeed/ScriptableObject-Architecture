using ScriptableObjectArchitecture.Instancers;
using UnityEditor;
using UnityEngine;

namespace ScriptableObjectArchitecture.Editor.Instancers
{
    /// <summary>
    /// Custom Editor for ScriptableObjectInstancer MonoBehaviours
    /// At runtime, it displays the instantiated SO in the inspector
    /// </summary>
    [CustomEditor(typeof(ScriptableObjectInstancer<>), true)]
    public class ScriptableObjectInstancerEditor : UnityEditor.Editor
    {
        private const string InstantiatedScriptableObjectLabel = "Instantiated ScriptableObject";
        
        private UnityEditor.Editor _soEditor;
        private bool _isSoEditorFoldoutOpened;
        
        private void OnEnable()
        {
            if(target is not IGetSo getSo)
            {
                return;
            }

            if (!Application.isPlaying)
            {
                return;
            }
            
            _soEditor = CreateEditor(getSo.So);
        }

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            if (!Application.isPlaying)
            {
                return;
            }

            EditorGUILayout.Space(10);
            
            _isSoEditorFoldoutOpened = EditorGUILayout.BeginFoldoutHeaderGroup(_isSoEditorFoldoutOpened, InstantiatedScriptableObjectLabel);
            if (_isSoEditorFoldoutOpened)
            {
                _soEditor.OnInspectorGUI();
            }
            EditorGUILayout.EndFoldoutHeaderGroup();
        }
    }
}