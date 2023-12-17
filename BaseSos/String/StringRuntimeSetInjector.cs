using UnityEngine;
using ScriptableObjectArchitecture;
using ScriptableObjectArchitecture.RuntimeSetInjectors;

namespace ScriptableObjectArchitecture.BaseSos
{
    [AddComponentMenu(AddComponentMenuConstants.RuntimeSetInjectorsPath + "String RuntimeSetInjector")]
    internal class StringRuntimeSetInjector : RuntimeSetInjector<string>
    {
    }
}
