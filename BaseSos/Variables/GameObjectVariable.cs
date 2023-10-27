using UnityEngine;

namespace ScriptableObjectArchitecture.Variables
{
    [CreateAssetMenu(fileName = "New GameObject Reference", menuName = "Variable/GameObject")]
    internal class GameObjectVariable : Variable<GameObject> { }
}