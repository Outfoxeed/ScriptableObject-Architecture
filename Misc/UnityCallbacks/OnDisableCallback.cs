using UnityEngine;

namespace ScriptableObjectArchitecture.Misc.UnityCallbacks
{
    [AddComponentMenu("Unity Callbacks/On Disable Unity Callbacks")]
    public class OnDisableCallback : OnUnityCallback
    {
        private void OnDisable()
        {
            _response.Invoke();
        }
    }
}