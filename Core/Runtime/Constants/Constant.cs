using ScriptableObjectArchitecture.Base;
using UnityEngine;

namespace ScriptableObjectArchitecture.Constants
{
    /// <summary>
    /// ScriptableObject with a constant value
    /// </summary>
    /// <typeparam name="T">Value type</typeparam>
    public abstract class Constant<T> : ScriptableObjectArchitectureObject
    {
        [field: SerializeField] public T Value { get; private set; }
    }
}