using UnityEngine;
using ScriptableObjectArchitecture;
using ScriptableObjectArchitecture.GameEventListeners;

namespace ScriptableObjectArchitecture.BaseSos
{
    [AddComponentMenu(AddComponentMenuConstants.GameEventListenersPath + "GameObject GameEventListener")]
    internal class GameObjectGameEventListener : GameEventListener<UnityEngine.GameObject>
    {
    }
}
