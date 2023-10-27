using UnityEngine;

namespace ScriptableObjectArchitecture.Variables
{
    [CreateAssetMenu(fileName = "New Color Reference", menuName = "Variable/Color")]
    internal class ColorVariable : Variable<Color> { }
}