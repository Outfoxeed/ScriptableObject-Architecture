using UnityEngine;
using ScriptableObjectArchitecture;
using ScriptableObjectArchitecture.VariableInstancers;

namespace ScriptableObjectArchitecture.BaseSos
{
    [AddComponentMenu(AddComponentMenuConstants.VariableInstancersPath + "GameObject VariableInstancer")]
    internal class GameObjectVariableInstancer : VariableInstancer<UnityEngine.GameObject>
    {
    }
}
