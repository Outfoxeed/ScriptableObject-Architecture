using UnityEngine;
using ScriptableObjectArchitecture;
using ScriptableObjectArchitecture.ReferenceListeners;

namespace ScriptableObjectArchitecture.BaseSos
{
    [AddComponentMenu(AddComponentMenuConstants.ReferenceListenersPath + "GameObject ReferenceListener")]
    internal class GameObjectReferenceListener : ReferenceListener<UnityEngine.GameObject>
    {
    }
}
