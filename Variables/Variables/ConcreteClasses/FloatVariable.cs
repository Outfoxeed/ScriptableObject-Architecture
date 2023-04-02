using UnityEngine;

namespace ScriptableObjectArchitecture.Variables.ConcreteClasses
{
    [CreateAssetMenu(fileName = "New Float Reference", menuName = "Variable/Float")]
    public class FloatVariable : Variable<float> { }
}