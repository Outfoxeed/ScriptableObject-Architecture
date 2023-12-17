using UnityEngine;
using ScriptableObjectArchitecture;
using ScriptableObjectArchitecture.RuntimeSetInjectors;

namespace ScriptableObjectArchitecture.BaseSos
{
    [AddComponentMenu(AddComponentMenuConstants.RuntimeSetInjectorsPath + "Vector3 RuntimeSetInjector")]
    internal class Vector3RuntimeSetInjector : RuntimeSetInjector<UnityEngine.Vector3>
    {
    }
}
