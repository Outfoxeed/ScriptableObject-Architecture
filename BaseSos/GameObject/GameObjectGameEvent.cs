using UnityEngine;
using ScriptableObjectArchitecture;
using ScriptableObjectArchitecture.GameEvents;

namespace ScriptableObjectArchitecture.BaseSos
{
  [CreateAssetMenu(menuName = CreateAssetMenuConstants.GameEventsPath + "GameObject")]
  internal class GameObjectGameEvent : GameEvent<UnityEngine.GameObject>
  {
  }
}
