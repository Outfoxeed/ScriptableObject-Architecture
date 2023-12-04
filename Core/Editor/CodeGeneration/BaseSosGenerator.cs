using ScriptableObjectArchitecture.Editor.CodeGeneration;
using UnityEditor;

namespace BaseSos
{
    public static class BaseSosGenerator
    {
        private const string NamespaceName = "ScriptableObjectArchitecture.BaseSos";
        
        [MenuItem("SO Arch/Generate Base Sos")]
        public static void GenerateBaseSos()
        {
            CodeGenerator.Generate("bool", customNamespaceName: NamespaceName, refreshAssetDatabase: false);
            CodeGenerator.Generate("float", customNamespaceName: NamespaceName, refreshAssetDatabase: false);
            CodeGenerator.Generate("double", customNamespaceName: NamespaceName, refreshAssetDatabase: false);
            CodeGenerator.Generate("int", customNamespaceName: NamespaceName, refreshAssetDatabase: false);
            CodeGenerator.Generate("string", customNamespaceName: NamespaceName, refreshAssetDatabase: false);
            CodeGenerator.Generate("UnityEngine.Color", customNamespaceName: NamespaceName, refreshAssetDatabase: false);
            CodeGenerator.Generate("UnityEngine.Vector2", customNamespaceName: NamespaceName, refreshAssetDatabase: false);
            CodeGenerator.Generate("UnityEngine.Vector3", customNamespaceName: NamespaceName, refreshAssetDatabase: false);
            CodeGenerator.Generate("UnityEngine.GameObject", customNamespaceName: NamespaceName, refreshAssetDatabase: false);
            AssetDatabase.Refresh();
        }
    }
}