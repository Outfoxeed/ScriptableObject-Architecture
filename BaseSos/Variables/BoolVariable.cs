using UnityEngine;

namespace ScriptableObjectArchitecture.Variables
{
    [CreateAssetMenu(fileName = "New Bool Reference", menuName = "Variable/Bool")]
    internal class BoolVariable : Variable<bool> { }
}