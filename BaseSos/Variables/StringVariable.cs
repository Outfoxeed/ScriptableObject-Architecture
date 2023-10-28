using UnityEngine;

namespace ScriptableObjectArchitecture.Variables
{
    [CreateAssetMenu(menuName = CreateAssetMenuConstants.VariablesPath + "String")]
    internal class StringVariable : Variable<string> { }
}