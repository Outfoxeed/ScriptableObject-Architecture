using UnityEngine;

namespace ScriptableObjectArchitecture.Variables
{
    [CreateAssetMenu(menuName = CreateAssetMenuConstants.VariablesPath + "Bool")]
    internal class BoolVariable : Variable<bool> { }
}