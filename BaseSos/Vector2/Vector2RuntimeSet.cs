using UnityEngine;
using ScriptableObjectArchitecture;
using ScriptableObjectArchitecture.RuntimeSets;

namespace ScriptableObjectArchitecture.BaseSos
{
  [CreateAssetMenu(menuName = CreateAssetMenuConstants.RuntimeSetsPath + "Vector2")]
  internal class Vector2RuntimeSet : RuntimeSet<UnityEngine.Vector2>
  {
  }
}
