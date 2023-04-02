using System;
using ScriptableObjectArchitecture.Subscriptions;
using UnityEngine;

namespace ScriptableObjectArchitecture.GameEvents
{
    public abstract class ReadOnlyGameEvent<T> : ScriptableObject, IReadOnlyGameEvent<T>
    {
        public abstract IDisposable Subscribe(object subscriber, string subscriptionName, Action<T> callback);
        public abstract IDisposable Subscribe(object subscriber, string subscriptionName, Action callback);
    }
    
    public abstract class ReadOnlyGameEvent : ReadOnlyGameEvent<Empty>
    {
        
    }
}