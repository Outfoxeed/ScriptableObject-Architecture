using UnityEngine;

namespace ScriptableObjectArchitecture.Variables.ConcreteClasses
{
    [CreateAssetMenu(fileName = "New Bool Reference", menuName = "Variable/Bool")]
    internal class BoolVariable : Variable<bool> { }
}