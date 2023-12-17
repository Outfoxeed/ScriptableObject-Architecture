using UnityEngine;
using ScriptableObjectArchitecture;
using ScriptableObjectArchitecture.RuntimeSetInjectors;

namespace ScriptableObjectArchitecture.BaseSos
{
    [AddComponentMenu(AddComponentMenuConstants.RuntimeSetInjectorsPath + "Int RuntimeSetInjector")]
    internal class IntRuntimeSetInjector : RuntimeSetInjector<int>
    {
    }
}
