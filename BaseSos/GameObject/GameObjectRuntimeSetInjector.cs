using UnityEngine;
using ScriptableObjectArchitecture;
using ScriptableObjectArchitecture.RuntimeSetInjectors;

namespace ScriptableObjectArchitecture.BaseSos
{
    [AddComponentMenu(AddComponentMenuConstants.RuntimeSetInjectorsPath + "GameObject RuntimeSetInjector")]
    internal class GameObjectRuntimeSetInjector : RuntimeSetInjector<UnityEngine.GameObject>
    {
    }
}
