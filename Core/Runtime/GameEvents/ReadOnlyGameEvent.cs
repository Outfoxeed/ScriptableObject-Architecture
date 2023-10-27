using System;
using ScriptableObjectArchitecture.Base;

namespace ScriptableObjectArchitecture.GameEvents
{
    public abstract class ReadOnlyGameEvent<T> : ScriptableObjectArchitectureObject, IReadOnlyGameEvent<T>
    {
        public abstract IDisposable Subscribe(IObserver<T> observer);
    }
}