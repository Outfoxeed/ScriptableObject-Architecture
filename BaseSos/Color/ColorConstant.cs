using UnityEngine;
using ScriptableObjectArchitecture;
using ScriptableObjectArchitecture.Constants;

namespace ScriptableObjectArchitecture.BaseSos
{
  [CreateAssetMenu(menuName = CreateAssetMenuConstants.ConstantsPath + "Color")]
  internal class ColorConstant : Constant<UnityEngine.Color>
  {
  }
}
