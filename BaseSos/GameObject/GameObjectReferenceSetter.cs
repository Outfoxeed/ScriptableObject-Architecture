using UnityEngine;
using ScriptableObjectArchitecture;
using ScriptableObjectArchitecture.ReferenceSetters;

namespace ScriptableObjectArchitecture.BaseSos
{
    [AddComponentMenu(AddComponentMenuConstants.ReferenceSettersPath + "GameObject ReferenceSetter")]
    internal class GameObjectReferenceSetter : ReferenceSetter<UnityEngine.GameObject>
    {
    }
}
