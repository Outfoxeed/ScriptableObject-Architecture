using UnityEngine;

namespace ScriptableObjectArchitecture.Misc.UnityCallbacks
{
    [AddComponentMenu("Unity Callbacks/Awake Unity Callbacks")]
    public class OnAwakeCallback : OnUnityCallback
    {
        private void Awake()
        {
            _response.Invoke();
        }
    }
}