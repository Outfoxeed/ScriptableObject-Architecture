using UnityEngine;
using ScriptableObjectArchitecture;
using ScriptableObjectArchitecture.GameEvents;

namespace ScriptableObjectArchitecture.BaseSos
{
  [CreateAssetMenu(menuName = CreateAssetMenuConstants.GameEventsPath + "Bool")]
  internal class BoolGameEvent : GameEvent<bool>
  {
  }
}
