using UnityEngine;

namespace ScriptableObjectArchitecture.GameEventListeners
{
    [AddComponentMenu(AddComponentMenuConstants.GameEventListenersPath + "Int Game Event Listener")]
    internal class IntGameEventListener : GameEventListener<int>
    {
    }
}