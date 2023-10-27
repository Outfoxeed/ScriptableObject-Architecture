using System;
using ScriptableObjectArchitecture.Base;
using UniRx;

namespace ScriptableObjectArchitecture.Variables
{
    /// <summary>
    /// ScriptableObject with a generic Read-Only value on which we can subscribe to
    /// </summary>
    /// <typeparam name="T">object</typeparam>
    public abstract class ReadOnlyVariable<T> : ScriptableObjectArchitectureObject, IReadOnlyVariable<T>
    {
        public bool HasValue => true;
        
        public T Value => GetValue();
        protected abstract T GetValue();

        public abstract IDisposable Subscribe(IObserver<T> observer);
    }
}