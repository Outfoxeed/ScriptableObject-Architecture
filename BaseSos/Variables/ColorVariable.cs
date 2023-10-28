using UnityEngine;

namespace ScriptableObjectArchitecture.Variables
{
    [CreateAssetMenu(menuName = CreateAssetMenuConstants.VariablesPath + "Color")]
    internal class ColorVariable : Variable<Color> { }
}