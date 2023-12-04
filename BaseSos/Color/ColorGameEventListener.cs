using UnityEngine;
using ScriptableObjectArchitecture;
using ScriptableObjectArchitecture.GameEventListeners;

namespace ScriptableObjectArchitecture.BaseSos
{
    [AddComponentMenu(AddComponentMenuConstants.GameEventListenersPath + "Color GameEventListener")]
    internal class ColorGameEventListener : GameEventListener<UnityEngine.Color>
    {
    }
}
