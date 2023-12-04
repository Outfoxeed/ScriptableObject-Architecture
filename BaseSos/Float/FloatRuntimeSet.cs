using UnityEngine;
using ScriptableObjectArchitecture;
using ScriptableObjectArchitecture.RuntimeSets;

namespace ScriptableObjectArchitecture.BaseSos
{
  [CreateAssetMenu(menuName = CreateAssetMenuConstants.RuntimeSetsPath + "Float")]
  internal class FloatRuntimeSet : RuntimeSet<float>
  {
  }
}
