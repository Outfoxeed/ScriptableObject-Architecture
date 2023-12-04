using UnityEngine;
using ScriptableObjectArchitecture;
using ScriptableObjectArchitecture.Variables;

namespace ScriptableObjectArchitecture.BaseSos
{
  [CreateAssetMenu(menuName = CreateAssetMenuConstants.VariablesPath + "Double")]
  internal class DoubleVariable : Variable<double>
  {
  }
}
