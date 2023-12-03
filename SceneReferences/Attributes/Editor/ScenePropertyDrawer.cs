using System;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;

namespace ScriptableObjectArchitecture.SceneReferences
{
    [CustomPropertyDrawer(typeof(SceneAttribute))]
    public class ScenePropertyDrawer : UnityEditor.PropertyDrawer
    {
        private const string SceneListItem = "{0} ({1})";
        private const string ScenePattern = @".+\/(.+)\.unity";

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            string[] scenes = GetScenes();
            bool noSceneInBuildSettings = scenes.Length == 0;
            if (noSceneInBuildSettings)
            {
                DrawErrorHelpBox(position, label, "There is no scene available in the BuildSettings");
                return;
            }

            string[] sceneOptions = GetSceneOptions(scenes);
            switch (property.propertyType)
            {
                case SerializedPropertyType.String:
                    DrawPropertyForString(position, property, label, scenes, sceneOptions);
                    break;
                case SerializedPropertyType.Integer:
                    DrawPropertyForInt(position, property, label, sceneOptions);
                    break;
                default:
                    DrawErrorHelpBox(position, label,
                        $"The Scene field '{property.name}' cannot be other than 'int' or 'string'");
                    break;
            }

            EditorGUI.EndProperty();
        }
        
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            float result = base.GetPropertyHeight(property, label);

            bool invalidPropertyType = property.propertyType != SerializedPropertyType.String &&
                                       property.propertyType != SerializedPropertyType.Integer;
            bool noScenesAvailable = GetScenes().Length == 0;
            if (invalidPropertyType || noScenesAvailable)
            {
                result += EditorGUIUtility.singleLineHeight * 2.0f;
            }

            return result;
        }

        private string[] GetScenes()
        {
            return EditorBuildSettings.scenes
                .Where(scene => scene.enabled)
                .Select(scene => Regex.Match(scene.path, ScenePattern).Groups[1].Value)
                .ToArray();
        }

        private string[] GetSceneOptions(string[] scenes)
        {
            return scenes.Select((s, i) => string.Format(SceneListItem, s, i)).ToArray();
        }

        private static void DrawPropertyForString(Rect rect, SerializedProperty property, GUIContent label,
            string[] scenes, string[] sceneOptions)
        {
            int index = IndexOf(scenes, property.stringValue);
            int newIndex = EditorGUI.Popup(rect, label.text, index, sceneOptions);
            string newScene = scenes[newIndex];

            if (!property.stringValue.Equals(newScene, StringComparison.Ordinal))
            {
                property.stringValue = scenes[newIndex];
            }
        }

        private static void DrawPropertyForInt(Rect rect, SerializedProperty property, GUIContent label,
            string[] sceneOptions)
        {
            int index = property.intValue;
            int newIndex = EditorGUI.Popup(rect, label.text, index, sceneOptions);

            if (property.intValue != newIndex)
            {
                property.intValue = newIndex;
            }
        }

        private static int IndexOf(string[] scenes, string scene)
        {
            var index = Array.IndexOf(scenes, scene);
            return Mathf.Clamp(index, 0, scenes.Length - 1);
        }

        private void DrawErrorHelpBox(Rect position, GUIContent label, string helpBoxMessage)
        {
            float singleLineHeight = EditorGUIUtility.singleLineHeight;
            Rect labelRect = new Rect(position.position,
                new Vector2(position.width, singleLineHeight));
            EditorGUI.LabelField(labelRect, label);

            Rect helpBoxRect = new Rect(position.x, position.y + singleLineHeight, position.width,
                position.height - singleLineHeight);
            EditorGUI.HelpBox(helpBoxRect, helpBoxMessage, MessageType.Error);
        }
    }
}