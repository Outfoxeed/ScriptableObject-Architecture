using UnityEngine;
using ScriptableObjectArchitecture;
using ScriptableObjectArchitecture.Variables;

namespace ScriptableObjectArchitecture.BaseSos
{
  [CreateAssetMenu(menuName = CreateAssetMenuConstants.VariablesPath + "Vector2")]
  internal class Vector2Variable : Variable<UnityEngine.Vector2>
  {
  }
}
