using UnityEngine;
using ScriptableObjectArchitecture;
using ScriptableObjectArchitecture.Variables;

namespace ScriptableObjectArchitecture.BaseSos
{
  [CreateAssetMenu(menuName = CreateAssetMenuConstants.VariablesPath + "Vector3")]
  internal class Vector3Variable : Variable<UnityEngine.Vector3>
  {
  }
}
