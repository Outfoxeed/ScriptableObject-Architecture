using UnityEngine;
using ScriptableObjectArchitecture;
using ScriptableObjectArchitecture.RuntimeSets;

namespace ScriptableObjectArchitecture.BaseSos
{
  [CreateAssetMenu(menuName = CreateAssetMenuConstants.RuntimeSetsPath + "GameObject")]
  internal class GameObjectRuntimeSet : RuntimeSet<UnityEngine.GameObject>
  {
  }
}
