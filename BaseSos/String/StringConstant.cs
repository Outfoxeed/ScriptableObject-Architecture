using UnityEngine;
using ScriptableObjectArchitecture;
using ScriptableObjectArchitecture.Constants;

namespace ScriptableObjectArchitecture.BaseSos
{
  [CreateAssetMenu(menuName = CreateAssetMenuConstants.ConstantsPath + "String")]
  internal class StringConstant : Constant<string>
  {
  }
}
