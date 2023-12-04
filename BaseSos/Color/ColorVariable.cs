using UnityEngine;
using ScriptableObjectArchitecture;
using ScriptableObjectArchitecture.Variables;

namespace ScriptableObjectArchitecture.BaseSos
{
  [CreateAssetMenu(menuName = CreateAssetMenuConstants.VariablesPath + "Color")]
  internal class ColorVariable : Variable<UnityEngine.Color>
  {
  }
}
