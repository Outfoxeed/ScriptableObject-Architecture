using System;
using ScriptableObjectArchitecture.Instancers;
using ScriptableObjectArchitecture.Variables;

namespace ScriptableObjectArchitecture.VariableInstancers
{
    /// <summary>
    /// MonoBehaviour class faking the job of a Variable by instantiating a concrete Variable at Awake
    /// and delegating its job to it. 
    /// </summary>
    /// <typeparam name="T">Type of Variable's value</typeparam>
    [System.Serializable]
    public class VariableInstancer<T> : ScriptableObjectInstancer<Variable<T>>, IVariable<T>
    {
        public IDisposable Subscribe(IObserver<T> observer) => So.Subscribe(observer);
        public T Value { get => So.Value; set => So.Value = value; }
        public bool HasValue => So != null;

        public T SetValueAndForceNotify(T value) => So.SetValueAndForceNotify(value);
    }
}