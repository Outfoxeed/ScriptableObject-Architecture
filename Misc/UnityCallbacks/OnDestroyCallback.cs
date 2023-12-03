using UnityEngine;

namespace ScriptableObjectArchitecture.Misc.UnityCallbacks
{
    [AddComponentMenu("Unity Callbacks/On Destroy Unity Callbacks")]
    public class OnDestroyCallback : OnUnityCallback
    {
        private void OnDestroy()
        {
            _response.Invoke();
        }
    }
}