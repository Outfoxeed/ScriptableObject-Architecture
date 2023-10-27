using System;

namespace ScriptableObjectArchitecture.GameEvents
{
    public interface IReadOnlyGameEvent
    {
    }
    
    public interface IReadOnlyGameEvent<out T> : IReadOnlyGameEvent, IObservable<T>
    {
    }
}