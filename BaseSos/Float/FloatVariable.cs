using UnityEngine;
using ScriptableObjectArchitecture;
using ScriptableObjectArchitecture.Variables;

namespace ScriptableObjectArchitecture.BaseSos
{
  [CreateAssetMenu(menuName = CreateAssetMenuConstants.VariablesPath + "Float")]
  internal class FloatVariable : Variable<float>
  {
  }
}
