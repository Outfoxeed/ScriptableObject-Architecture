using UnityEngine;
using ScriptableObjectArchitecture;
using ScriptableObjectArchitecture.GameEvents;

namespace ScriptableObjectArchitecture.BaseSos
{
  [CreateAssetMenu(menuName = CreateAssetMenuConstants.GameEventsPath + "Int")]
  internal class IntGameEvent : GameEvent<int>
  {
  }
}
