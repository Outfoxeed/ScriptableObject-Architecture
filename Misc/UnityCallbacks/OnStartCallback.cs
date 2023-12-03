using UnityEngine;

namespace ScriptableObjectArchitecture.Misc.UnityCallbacks
{
    [AddComponentMenu("Unity Callbacks/Start Unity Callbacks")]
    public class OnStartCallback : OnUnityCallback
    {
        private void Start()
        {
            _response.Invoke();
        }
    }
}