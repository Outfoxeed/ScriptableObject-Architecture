using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using ScriptableObjectArchitecture.Constants;
using ScriptableObjectArchitecture.GameEventListeners;
using ScriptableObjectArchitecture.GameEvents;
using ScriptableObjectArchitecture.VariableInstancers;
using ScriptableObjectArchitecture.ReferenceListeners;
using ScriptableObjectArchitecture.ReferenceSetters;
using ScriptableObjectArchitecture.RuntimeSets;
using ScriptableObjectArchitecture.Variables;
using UnityEditor;
using UnityEngine;

namespace ScriptableObjectArchitecture.Editor.CodeGeneration
{
    public class ScriptGenerator
    {
        private const string GeneratedScriptsFolderName = "GENERATED_SCRIPTS_SOArch/";
        
        private const string TemplatesFolderRelativePath = "Templates/";
        private const string SoArchObjectTemplateRelativePath = TemplatesFolderRelativePath + "GenericScriptableObjectTemplate";
        private const string SoArchMonoBehaviourTemplateRelativePath = TemplatesFolderRelativePath + "GenericMonoBehaviourTemplate";
        
        private const string DefaultGeneratedScriptNamespaceName = "DefaultGeneratedScriptNamespace";
        
        private string GeneratedScriptsFolderPath
        {
            get
            {
                if (string.IsNullOrEmpty(_generatedScriptsFolderPath))
                {
                    _generatedScriptsFolderPath = Application.dataPath + '\\' + GeneratedScriptsFolderName + '\\';
                }

                return _generatedScriptsFolderPath;
            }
        }

        private string ScriptFolderPath
        {
            get
            {
                if (string.IsNullOrEmpty(_scriptFolderPath))
                {
                    _scriptFolderPath = GetScriptFolderPath();
                }

                return _scriptFolderPath;
            }
        }

        private string _generatedScriptsFolderPath;
        private string _scriptFolderPath;

        public void Generate(string targetTypeName, string customNamespaceName)
        {
            if (string.IsNullOrEmpty(targetTypeName))
            {
                throw new ScriptGenerationException("targetTypeName is null");
            }

            Dictionary<string, string> scriptGenerationArgs = new Dictionary<string, string>()
            {
                {
                    "NamespaceName", string.IsNullOrEmpty(customNamespaceName)
                        ? DefaultGeneratedScriptNamespaceName
                        : customNamespaceName
                },
                {
                    "TargetTypeName", targetTypeName.Split('.')[^1]
                },
                {
                    "TargetTypeFullName", targetTypeName
                },
                {
                    "ParentClassName", "Variable"
                }
            };
            
            // Generate result folder if not created
            string folderPath = GeneratedScriptsFolderPath + scriptGenerationArgs["TargetTypeName"] + '\\'; 
            if (!File.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            // Variable
            GenerateScript(
                templatePath: ScriptFolderPath + SoArchObjectTemplateRelativePath,
                folderResultPath: folderPath,
                parentClassName: GetClassName(typeof(Variable<>)),
                args: scriptGenerationArgs
            );
            
            // GameEvent
            GenerateScript(
                templatePath: ScriptFolderPath + SoArchObjectTemplateRelativePath,
                folderResultPath: folderPath,
                parentClassName: GetClassName(typeof(GameEvent<>)),
                args: scriptGenerationArgs
            );
            
            // RuntimeSet
            GenerateScript(
                templatePath: ScriptFolderPath + SoArchObjectTemplateRelativePath,
                folderResultPath: folderPath,
                parentClassName: GetClassName(typeof(RuntimeSet<>)),
                args: scriptGenerationArgs
            );
            
            // Constant
            GenerateScript(
                templatePath: ScriptFolderPath + SoArchObjectTemplateRelativePath,
                folderResultPath: folderPath,
                parentClassName: GetClassName(typeof(Constant<>)),
                args: scriptGenerationArgs
            );
            
            // GameEvent Listener
            GenerateScript(
                templatePath: ScriptFolderPath + SoArchMonoBehaviourTemplateRelativePath,
                folderResultPath: folderPath,
                parentClassName: GetClassName(typeof(GameEventListener<>)),
                args: scriptGenerationArgs
            );
            
            // Variable Instancer
            GenerateScript(
                templatePath: ScriptFolderPath + SoArchMonoBehaviourTemplateRelativePath,
                folderResultPath: folderPath,
                parentClassName: GetClassName(typeof(VariableInstancer<>)),
                args: scriptGenerationArgs
            );
            
            // Reference Listener
            GenerateScript(
                templatePath: ScriptFolderPath + SoArchMonoBehaviourTemplateRelativePath,
                folderResultPath: folderPath,
                parentClassName: GetClassName(typeof(ReferenceListener<>)),
                args: scriptGenerationArgs
            );
            
            // Reference Setter
            GenerateScript(
                templatePath: ScriptFolderPath + SoArchMonoBehaviourTemplateRelativePath,
                folderResultPath: folderPath,
                parentClassName: GetClassName(typeof(ReferenceSetter<>)),
                args: scriptGenerationArgs
            );

            AssetDatabase.Refresh();
        }

        private static string GetClassName(System.Type type)
        {
            return type.Name.Split('`')[0];
        }

        /// <summary>
        /// Create a script file from given template and at wanted folder
        /// </summary>
        /// <param name="parentClassName">Name of the class the new script inherit from</param>
        /// <param name="args">Args used for replacing the parameters in the template</param>
        private void GenerateScript(string templatePath, string folderResultPath, string parentClassName, Dictionary<string, string> args)
        {
            args["ParentClassName"] = parentClassName;
            File.WriteAllText(folderResultPath + $"{args["TargetTypeName"]}{parentClassName}.cs", GenerateScriptText(templatePath, args));
        }

        /// <summary>
        /// Generate a text from a template by replacing its parameters by wanted values
        /// </summary>
        /// <param name="absoluteTemplatePath">Absolute path of the template</param>
        /// <param name="args">The values to replace in the template text</param>
        /// <returns>The template text with the values replaced</returns>
        private string GenerateScriptText(string absoluteTemplatePath, IReadOnlyDictionary<string, string> args)
        {
            string result = File.ReadAllText(absoluteTemplatePath);
            if (string.IsNullOrEmpty(absoluteTemplatePath))
            {
                throw new ScriptGenerationException($"Template '{absoluteTemplatePath}' is null or empty");
            }

            Match a = null;
            const string pattern = @"\$(\w+)\$";
            while ((a = Regex.Match(result, pattern)).Success)
            {
                string key = a.Value[1..^1];

                if (!args.TryGetValue(key, out string newValue))
                {
                    throw new ScriptGenerationException($"No given value to replace the key '{key}'");
                }

                result = result.Replace(a.Value, newValue);
            }

            return result;
        }

        private string GetScriptFolderPath()
        {
            string scriptName = $"{typeof(ScriptGenerator).ToString().Split('.')[^1]}.cs";
            string[] res = System.IO.Directory.GetFiles(Application.dataPath, scriptName, SearchOption.AllDirectories);
            if (res.Length == 0)
            {
                Debug.LogError("error message ....");
                return null;
            }

            string path = res[0].Replace(scriptName, "").Replace("\\", "/");
            return path;
        }
    }

    public class ScriptGenerationException : Exception
    {
        public ScriptGenerationException(string message) : base(message)
        {
        }
    }
}