using UnityEngine;

namespace ScriptableObjectArchitecture.GameEventListeners
{
    [AddComponentMenu(AddComponentMenuConstants.GameEventListenersPath + "String Game Event Listener")]
    internal class StringGameEventListener : GameEventListener<string>
    {
    }
}