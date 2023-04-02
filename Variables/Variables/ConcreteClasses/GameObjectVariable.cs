using UnityEngine;

namespace ScriptableObjectArchitecture.Variables.ConcreteClasses
{
    [CreateAssetMenu(fileName = "New GameObject Reference", menuName = "Variable/GameObject")]
    internal class GameObjectVariable : Variable<GameObject> { }
}