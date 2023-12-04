using UnityEngine;
using ScriptableObjectArchitecture;
using ScriptableObjectArchitecture.GameEventListeners;

namespace ScriptableObjectArchitecture.BaseSos
{
    [AddComponentMenu(AddComponentMenuConstants.GameEventListenersPath + "Vector2 GameEventListener")]
    internal class Vector2GameEventListener : GameEventListener<UnityEngine.Vector2>
    {
    }
}
