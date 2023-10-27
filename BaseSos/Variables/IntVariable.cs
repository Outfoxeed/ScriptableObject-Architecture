using UnityEngine;

namespace ScriptableObjectArchitecture.Variables
{
    [CreateAssetMenu(fileName = "New Int Reference", menuName = "Variable/Int")]
    internal class IntVariable : Variable<int> { }
}