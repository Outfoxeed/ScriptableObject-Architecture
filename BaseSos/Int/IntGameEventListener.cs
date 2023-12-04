using UnityEngine;
using ScriptableObjectArchitecture;
using ScriptableObjectArchitecture.GameEventListeners;

namespace ScriptableObjectArchitecture.BaseSos
{
    [AddComponentMenu(AddComponentMenuConstants.GameEventListenersPath + "Int GameEventListener")]
    internal class IntGameEventListener : GameEventListener<int>
    {
    }
}
