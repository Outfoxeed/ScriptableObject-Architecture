using UnityEngine;
using ScriptableObjectArchitecture;
using ScriptableObjectArchitecture.GameEventListeners;

namespace ScriptableObjectArchitecture.BaseSos
{
    [AddComponentMenu(AddComponentMenuConstants.GameEventListenersPath + "Float GameEventListener")]
    internal class FloatGameEventListener : GameEventListener<float>
    {
    }
}
