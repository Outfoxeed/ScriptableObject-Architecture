using UnityEngine;
using ScriptableObjectArchitecture;
using ScriptableObjectArchitecture.RuntimeSetInjectors;

namespace ScriptableObjectArchitecture.BaseSos
{
    [AddComponentMenu(AddComponentMenuConstants.RuntimeSetInjectorsPath + "Color RuntimeSetInjector")]
    internal class ColorRuntimeSetInjector : RuntimeSetInjector<UnityEngine.Color>
    {
    }
}
