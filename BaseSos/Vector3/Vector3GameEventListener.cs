using UnityEngine;
using ScriptableObjectArchitecture;
using ScriptableObjectArchitecture.GameEventListeners;

namespace ScriptableObjectArchitecture.BaseSos
{
    [AddComponentMenu(AddComponentMenuConstants.GameEventListenersPath + "Vector3 GameEventListener")]
    internal class Vector3GameEventListener : GameEventListener<UnityEngine.Vector3>
    {
    }
}
