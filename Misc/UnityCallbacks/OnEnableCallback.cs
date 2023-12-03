using UnityEngine;

namespace ScriptableObjectArchitecture.Misc.UnityCallbacks
{
    [AddComponentMenu("Unity Callbacks/On Enable Unity Callbacks")]
    public class OnEnableCallback : OnUnityCallback
    {
        private void OnEnable()
        {
            _response.Invoke();
        }
    }
}