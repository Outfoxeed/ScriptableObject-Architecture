using System;
using System.Collections.Generic;
using UniRx;

namespace ScriptableObjectArchitecture.RuntimeSets
{
    public interface IReadOnlyRuntimeSet
    {
        
    }
    
    public interface IReadOnlyRuntimeSet<T> : IReadOnlyRuntimeSet, IEnumerable<T>
    {
        T this[int index] { get; }
        bool Contains(T item);

        IObservable<AddedEvent<T>> ObserveAdd();
        IObservable<RemovedEvent<T>> ObserveRemove();
        IObservable<ChangedEvent<T>> ObserveChange();
        IObservable<Unit> ObserveClear();
    }
}