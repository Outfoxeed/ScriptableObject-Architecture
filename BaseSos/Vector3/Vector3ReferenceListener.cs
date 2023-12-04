using UnityEngine;
using ScriptableObjectArchitecture;
using ScriptableObjectArchitecture.ReferenceListeners;

namespace ScriptableObjectArchitecture.BaseSos
{
    [AddComponentMenu(AddComponentMenuConstants.ReferenceListenersPath + "Vector3 ReferenceListener")]
    internal class Vector3ReferenceListener : ReferenceListener<UnityEngine.Vector3>
    {
    }
}
