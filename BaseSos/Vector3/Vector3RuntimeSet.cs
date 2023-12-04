using UnityEngine;
using ScriptableObjectArchitecture;
using ScriptableObjectArchitecture.RuntimeSets;

namespace ScriptableObjectArchitecture.BaseSos
{
  [CreateAssetMenu(menuName = CreateAssetMenuConstants.RuntimeSetsPath + "Vector3")]
  internal class Vector3RuntimeSet : RuntimeSet<UnityEngine.Vector3>
  {
  }
}
