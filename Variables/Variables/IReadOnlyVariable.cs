using System;

namespace ScriptableObjectArchitecture.Variables
{
    public interface IReadOnlyVariable<out T>
    {
        public T GetValue();
        public IDisposable Subscribe(object subscriber, string subscriptionName, Action<T> callback, bool raiseCallback = true);
        public IDisposable Subscribe(object subscriber, string subscriptionName, Action callback, bool raiseCallback = true);
    }
}