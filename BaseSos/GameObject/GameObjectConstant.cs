using UnityEngine;
using ScriptableObjectArchitecture;
using ScriptableObjectArchitecture.Constants;

namespace ScriptableObjectArchitecture.BaseSos
{
  [CreateAssetMenu(menuName = CreateAssetMenuConstants.ConstantsPath + "GameObject")]
  internal class GameObjectConstant : Constant<UnityEngine.GameObject>
  {
  }
}
