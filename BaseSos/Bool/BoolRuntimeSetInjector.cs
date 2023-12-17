using UnityEngine;
using ScriptableObjectArchitecture;
using ScriptableObjectArchitecture.RuntimeSetInjectors;

namespace ScriptableObjectArchitecture.BaseSos
{
    [AddComponentMenu(AddComponentMenuConstants.RuntimeSetInjectorsPath + "Bool RuntimeSetInjector")]
    internal class BoolRuntimeSetInjector : RuntimeSetInjector<bool>
    {
    }
}
