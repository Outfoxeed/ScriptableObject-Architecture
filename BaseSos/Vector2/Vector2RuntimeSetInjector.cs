using UnityEngine;
using ScriptableObjectArchitecture;
using ScriptableObjectArchitecture.RuntimeSetInjectors;

namespace ScriptableObjectArchitecture.BaseSos
{
    [AddComponentMenu(AddComponentMenuConstants.RuntimeSetInjectorsPath + "Vector2 RuntimeSetInjector")]
    internal class Vector2RuntimeSetInjector : RuntimeSetInjector<UnityEngine.Vector2>
    {
    }
}
