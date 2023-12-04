using UnityEngine;
using ScriptableObjectArchitecture;
using ScriptableObjectArchitecture.GameEventListeners;

namespace ScriptableObjectArchitecture.BaseSos
{
    [AddComponentMenu(AddComponentMenuConstants.GameEventListenersPath + "String GameEventListener")]
    internal class StringGameEventListener : GameEventListener<string>
    {
    }
}
