using UnityEngine;
using ScriptableObjectArchitecture;
using ScriptableObjectArchitecture.RuntimeSetInjectors;

namespace ScriptableObjectArchitecture.BaseSos
{
    [AddComponentMenu(AddComponentMenuConstants.RuntimeSetInjectorsPath + "Float RuntimeSetInjector")]
    internal class FloatRuntimeSetInjector : RuntimeSetInjector<float>
    {
    }
}
