using UnityEngine;
using ScriptableObjectArchitecture;
using ScriptableObjectArchitecture.GameEvents;

namespace ScriptableObjectArchitecture.BaseSos
{
  [CreateAssetMenu(menuName = CreateAssetMenuConstants.GameEventsPath + "Vector2")]
  internal class Vector2GameEvent : GameEvent<UnityEngine.Vector2>
  {
  }
}
