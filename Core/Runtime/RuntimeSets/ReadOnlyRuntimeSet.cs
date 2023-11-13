using System;
using System.Collections;
using System.Collections.Generic;
using ScriptableObjectArchitecture.Base;
using UniRx;
using UnityEngine;

namespace ScriptableObjectArchitecture.RuntimeSets
{
    /// <summary>
    /// ScriptableObject containing a Read-Only reactive collection
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class ReadOnlyRuntimeSet<T> : ScriptableObjectArchitectureObject, IReadOnlyRuntimeSet<T>
    {
        public abstract IEnumerator<T> GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        
        public abstract int Count { get; }
        

        public T this[int index] => GetValue(index);
        protected abstract T GetValue(int index);

        public abstract bool Contains(T item);

        public abstract IObservable<CountChangedEvent> ObserveCountChanged();
        public abstract IObservable<AddedEvent<T>> ObserveAdd();
        public abstract IObservable<RemovedEvent<T>> ObserveRemove();
        public abstract IObservable<ChangedEvent<T>> ObserveChange();
        public abstract IObservable<Unit> ObserveClear();

    }
}
