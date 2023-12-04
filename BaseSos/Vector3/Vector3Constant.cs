using UnityEngine;
using ScriptableObjectArchitecture;
using ScriptableObjectArchitecture.Constants;

namespace ScriptableObjectArchitecture.BaseSos
{
  [CreateAssetMenu(menuName = CreateAssetMenuConstants.ConstantsPath + "Vector3")]
  internal class Vector3Constant : Constant<UnityEngine.Vector3>
  {
  }
}
