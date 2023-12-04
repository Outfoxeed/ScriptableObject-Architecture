using UnityEngine;
using ScriptableObjectArchitecture;
using ScriptableObjectArchitecture.GameEventListeners;

namespace ScriptableObjectArchitecture.BaseSos
{
    [AddComponentMenu(AddComponentMenuConstants.GameEventListenersPath + "Double GameEventListener")]
    internal class DoubleGameEventListener : GameEventListener<double>
    {
    }
}
