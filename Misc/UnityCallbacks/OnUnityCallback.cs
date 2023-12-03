using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectArchitecture.Misc.UnityCallbacks
{
    public abstract class OnUnityCallback : MonoBehaviour
    {
        [SerializeField] protected UnityEvent _response;
    }
}