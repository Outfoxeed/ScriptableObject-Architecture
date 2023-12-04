using UnityEngine;
using ScriptableObjectArchitecture;
using ScriptableObjectArchitecture.GameEvents;

namespace ScriptableObjectArchitecture.BaseSos
{
  [CreateAssetMenu(menuName = CreateAssetMenuConstants.GameEventsPath + "Vector3")]
  internal class Vector3GameEvent : GameEvent<UnityEngine.Vector3>
  {
  }
}
