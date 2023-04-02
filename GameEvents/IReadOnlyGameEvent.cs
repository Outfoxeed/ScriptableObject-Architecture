using System;

namespace ScriptableObjectArchitecture.GameEvents
{
    public interface IReadOnlyGameEvent
    {
        public IDisposable Subscribe(object subscriber, string subscriptionName, System.Action callback);
    }
    
    public interface IReadOnlyGameEvent<out T> : IReadOnlyGameEvent
    {
        public IDisposable Subscribe(object subscriber, string subscriptionName, System.Action<T> callback);
    }
}