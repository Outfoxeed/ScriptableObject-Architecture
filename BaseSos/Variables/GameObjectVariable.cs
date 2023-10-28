using UnityEngine;

namespace ScriptableObjectArchitecture.Variables
{
    [CreateAssetMenu(menuName = CreateAssetMenuConstants.VariablesPath + "GameObject")]
    internal class GameObjectVariable : Variable<GameObject> { }
}