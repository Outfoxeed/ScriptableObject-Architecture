using UnityEngine;
using ScriptableObjectArchitecture;
using ScriptableObjectArchitecture.Constants;

namespace ScriptableObjectArchitecture.BaseSos
{
  [CreateAssetMenu(menuName = CreateAssetMenuConstants.ConstantsPath + "Double")]
  internal class DoubleConstant : Constant<double>
  {
  }
}
