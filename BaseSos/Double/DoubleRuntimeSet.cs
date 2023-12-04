using UnityEngine;
using ScriptableObjectArchitecture;
using ScriptableObjectArchitecture.RuntimeSets;

namespace ScriptableObjectArchitecture.BaseSos
{
  [CreateAssetMenu(menuName = CreateAssetMenuConstants.RuntimeSetsPath + "Double")]
  internal class DoubleRuntimeSet : RuntimeSet<double>
  {
  }
}
