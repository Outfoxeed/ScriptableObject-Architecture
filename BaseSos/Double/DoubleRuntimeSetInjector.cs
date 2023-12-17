using UnityEngine;
using ScriptableObjectArchitecture;
using ScriptableObjectArchitecture.RuntimeSetInjectors;

namespace ScriptableObjectArchitecture.BaseSos
{
    [AddComponentMenu(AddComponentMenuConstants.RuntimeSetInjectorsPath + "Double RuntimeSetInjector")]
    internal class DoubleRuntimeSetInjector : RuntimeSetInjector<double>
    {
    }
}
