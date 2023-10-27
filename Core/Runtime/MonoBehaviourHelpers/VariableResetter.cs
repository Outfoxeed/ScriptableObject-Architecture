using System.Linq;
using ScriptableObjectArchitecture.Base;
using UnityEngine;

namespace ScriptableObjectArchitecture.MonoBehaviourHelpers
{
    /// <summary>
    /// Resets all the ScriptableObject inheriting from IReset located in the Resources
    /// </summary>
    //TODO: editor icon
    // [EditorIcon("atom-icon-delicate")]
    public class VariableResetter : MonoBehaviour
    {
        public void Awake()
        {
            foreach (IReset resettable in Resources.FindObjectsOfTypeAll<ScriptableObject>()
                         .OfType<IReset>())
            {
                resettable.Reset();
            }
        }
    }
}