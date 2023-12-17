using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using ScriptableObjectArchitecture.Constants;
using ScriptableObjectArchitecture.GameEventListeners;
using ScriptableObjectArchitecture.GameEvents;
using ScriptableObjectArchitecture.ReferenceListeners;
using ScriptableObjectArchitecture.ReferenceSetters;
using ScriptableObjectArchitecture.RuntimeSets;
using ScriptableObjectArchitecture.VariableInstancers;
using ScriptableObjectArchitecture.Variables;
using ScriptableObjectArchitecture.RuntimeSetInjectors;
using UnityEditor;
using UnityEngine;

namespace ScriptableObjectArchitecture.Editor.CodeGeneration
{
    public static class CodeGenerator
    {
        private const string GeneratedScriptsFolderName = "GENERATED_SCRIPTS_SOArch/";
        
        private const string TemplatesFolderRelativePath = "Templates/";
        private const string SoArchObjectTemplateRelativePath = TemplatesFolderRelativePath + "GenericScriptableObjectTemplate";
        private const string SoArchMonoBehaviourTemplateRelativePath = TemplatesFolderRelativePath + "GenericMonoBehaviourTemplate";
        
        private const string DefaultGeneratedScriptNamespaceName = "DefaultGeneratedScriptNamespace";
        
        private static string GeneratedScriptsFolderPath
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

        private static string ScriptFolderPath
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

        private static string _generatedScriptsFolderPath;
        private static string _scriptFolderPath;

        public static void Generate(string targetTypeFullName, string targetTypeDisplayName = null,
            string customNamespaceName = null, bool refreshAssetDatabase = true)
        {
            if (string.IsNullOrEmpty(targetTypeFullName))
            {
                throw new ScriptGenerationException($"{nameof(targetTypeFullName)} is null");
            }

            string namespaceName = string.IsNullOrEmpty(customNamespaceName)
                ? DefaultGeneratedScriptNamespaceName
                : customNamespaceName;
            string targetTypeName = string.IsNullOrEmpty(targetTypeDisplayName)
                ? targetTypeFullName.Split('.')[^1]
                : targetTypeDisplayName;
            targetTypeName = string.Concat(targetTypeName[0].ToString().ToUpper(), targetTypeName.Substring(1));
            
            Dictionary<string, string> scriptGenerationArgs = new Dictionary<string, string>()
            {
                { "NamespaceName", namespaceName },
                { "TargetTypeName", targetTypeName },
                { "TargetTypeFullName", targetTypeFullName },
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
            
            // RuntimeSet Injector
            GenerateScript(
                templatePath: ScriptFolderPath + SoArchMonoBehaviourTemplateRelativePath,
                folderResultPath: folderPath,
                parentClassName: GetClassName(typeof(RuntimeSetInjector<>)),
                args: scriptGenerationArgs
            );

            if (refreshAssetDatabase)
            {
                AssetDatabase.Refresh();
            }
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
        private static void GenerateScript(string templatePath, string folderResultPath, string parentClassName, Dictionary<string, string> args)
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
        private static string GenerateScriptText(string absoluteTemplatePath, IReadOnlyDictionary<string, string> args)
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

        private static string GetScriptFolderPath()
        {
            string scriptName = $"{typeof(CodeGenerator).ToString().Split('.')[^1]}.cs";
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
}