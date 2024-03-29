﻿using UnityEditor;
using UnityEngine;

namespace ScriptableObjectArchitecture.Editor.CodeGeneration
{
    public class CodeGeneratorWindow : EditorWindow
    {
        private string _targetTypeFullName = "";
        private bool _useCustomTargetDisplayName = false;
        private string _customTargetTypeDisplayName = ""; 
        private bool _useCustomNamespaceName = true;
        private string _customNamespaceName = "MyNamespace";

        private Vector2 _scrollPos;

        [MenuItem(MenuItemConstants.CodeGeneratorWindow)]
        private static void ShowWindow()
        {
            var window = GetWindow<CodeGeneratorWindow>();
            window.titleContent = new GUIContent("SO Arch - Code Generator");
            window.Show();
        }

        private void OnGUI()
        {
            using var scrollViewScope = new GUILayout.ScrollViewScope(_scrollPos);
            _scrollPos = scrollViewScope.scrollPosition;
                
            DrawHelpBoxes();

            GUILayout.Space(10);
            
            DrawParameters();

            GUILayout.Space(5);
            
            DrawGenerateButton();
        }

        private void DrawGenerateButton()
        {
            var defaultColor = GUI.contentColor;
            GUI.contentColor = UnityEngine.Random.ColorHSV(0f, 1f, 1f, 1f, 1f, 1f);
            if (GUILayout.Button("Generate"))
            {
                CodeGenerator.Generate(_targetTypeFullName,
                    _useCustomTargetDisplayName ? _customTargetTypeDisplayName : null,
                    _useCustomNamespaceName ? _customNamespaceName : null
                );
            }
            GUI.contentColor = defaultColor;
        }

        private void DrawParameters()
        {
            GUILayout.Label("Config:");
            _targetTypeFullName = EditorGUILayout.TextField("Target Type Full Name", _targetTypeFullName);
            
            _useCustomTargetDisplayName = EditorGUILayout.Toggle("Use Custom Target Display Name", _useCustomTargetDisplayName);
            if (_useCustomTargetDisplayName)
            {
                _customTargetTypeDisplayName = EditorGUILayout.TextField("Target Type Display Name", _customTargetTypeDisplayName);
            }
            
            _useCustomNamespaceName = EditorGUILayout.Toggle("Use Custom Namespace Name", _useCustomNamespaceName);
            if (_useCustomNamespaceName)
            {
                _customNamespaceName = EditorGUILayout.TextField("Custom Namespace Name", _customNamespaceName);
            }
        }

        private void DrawHelpBoxes()
        {
            EditorGUILayout.HelpBox(@"WHAT:

This window's purpose is to generate the Variable/GameEvent/RuntimeSets/Constants/... 
and all the expected MonoBehaviour classes linked to them like ReferenceListeners/Setters etc...",
                MessageType.Info
            );

            EditorGUILayout.HelpBox(
                @$"HOW TO:

- Give the full name of the Type from which the Variable/GameEvents/etc.. are going to be be generated (ex: 'UnityEngine.SceneManagement.Scene')

- You can choose to define a namespace for all this generated scripts, check the toggle if you want to

- If the toggle has been ticked, type the name of the namespace you want to use (ex: 'MyNamespace')",
                MessageType.Info
            );
        }
    }
}