using UnityEngine;
using ScriptableObjectArchitecture;
using ScriptableObjectArchitecture.VariableInstancers;

namespace ScriptableObjectArchitecture.BaseSos
{
    [AddComponentMenu(AddComponentMenuConstants.VariableInstancersPath + "Vector3 VariableInstancer")]
    internal class Vector3VariableInstancer : VariableInstancer<UnityEngine.Vector3>
    {
    }
}
