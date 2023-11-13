using UnityEngine;

namespace ScriptableObjectArchitecture.Base
{
    /// <summary>
    /// Base class of the ScriptableObject used in the SO Architecture
    /// </summary>
    public abstract class ScriptableObjectArchitectureObject : ScriptableObject
    {
#if UNITY_EDITOR
        //TODO: could be moved into Variable and GameEvent or a ReactiveScriptableObjectArchitectureObject
        [field: SerializeField] protected bool DebugMode { get; private set; }
        [SerializeField, TextArea(3, 10)] private string _developerDescription;
#endif
    }
}