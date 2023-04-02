using UnityEngine;

namespace ScriptableObjectArchitecture.Variables.ConcreteClasses
{
    [CreateAssetMenu(fileName = "New String Reference", menuName = "Variable/String")]
    internal class StringVariable : Variable<string> { }
}