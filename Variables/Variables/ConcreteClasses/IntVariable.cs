using UnityEngine;

namespace ScriptableObjectArchitecture.Variables.ConcreteClasses
{
    [CreateAssetMenu(fileName = "New Int Reference", menuName = "Variable/Int")]
    internal class IntVariable : Variable<int> { }
}