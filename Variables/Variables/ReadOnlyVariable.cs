using System;

namespace ScriptableObjectArchitecture.Variables
{
    /// <summary>
    /// ScriptableObject with a generic Read-Only value on which we can subscribe to
    /// </summary>
    /// <typeparam name="T">object</typeparam>
    public abstract class ReadOnlyVariable<T> : ScriptableObjectArchitectureObject, IReadOnlyVariable<T>
    {
        public T Value => GetValue();
        public abstract T GetValue();
        public abstract IDisposable Subscribe(object subscriber, string subscriptionName, Action<T> callback, bool raiseCallback = true);
        public abstract IDisposable Subscribe(object subscriber, string subscriptionName, Action callback, bool raiseCallback = true);
    }
}