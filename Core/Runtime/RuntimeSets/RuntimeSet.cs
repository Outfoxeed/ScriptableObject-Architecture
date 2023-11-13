using System;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace ScriptableObjectArchitecture.RuntimeSets
{
    public class RuntimeSet<T> : ReadOnlyRuntimeSet<T>, IRuntimeSet<T>
    {
        [SerializeField] private List<T> _collection;

        private Action<CountChangedEvent> _onCountChanged;
        private Action<AddedEvent<T>> _onElementAdded;
        private Action<RemovedEvent<T>> _onElementRemoved;
        private Action<ChangedEvent<T>> _onElementChanged;
        private Action<Unit> _onCleared;

        public override IEnumerator<T> GetEnumerator() => _collection.GetEnumerator();

        public override int Count => _collection.Count;
        public new T this[int index]
        {
            get => _collection[index];
            set
            {
                var oldValue = _collection[index];
                _collection[index] = value;
                _onElementChanged?.Invoke(new ChangedEvent<T>(oldValue, value));
            }
        }

        protected override T GetValue(int index) => _collection[index];

        private void Awake()
        {
            _collection = new List<T>();
        }

        public override bool Contains(T item) => _collection.Contains(item);
        public int IndexOf(T item) => _collection.IndexOf(item);
        public void Insert(int index, T item)
        {
            _collection.Insert(index, item);
            
            // Events
            _onElementAdded?.Invoke(new AddedEvent<T>(item, index));
            _onCountChanged?.Invoke(new CountChangedEvent(_collection.Count + 1, _collection.Count));
        }
        
        public void Add(T item)
        {
            _collection.Add(item);

            // Events
            int newCount = _collection.Count;
            _onElementAdded?.Invoke(new AddedEvent<T>(item, newCount - 1));
            _onCountChanged?.Invoke(new CountChangedEvent(newCount - 1, newCount));
        }

        #region Remove
        public void RemoveAt(int index)
        {
            T removedValue = GetValue(index);
            _collection.RemoveAt(index);
            
            // Events
            _onElementRemoved?.Invoke(new RemovedEvent<T>(removedValue, index));
            _onCountChanged?.Invoke(new CountChangedEvent(_collection.Count + 1, _collection.Count));
        }
        public bool Remove(T item)
        {
            int index = IndexOf(item);
            if (index < 0)
            {
                return false;
            }

            this.RemoveAt(index);
            return true;
        }
        #endregion

        public void Clear()
        {
            T[] oldValues = _collection.ToArray();
            _collection.Clear();

            // Events
            for (int i = 0; i < oldValues.Length; i++)
            {
                _onElementRemoved?.Invoke(new RemovedEvent<T>(oldValues[i], i));
            }
            _onCleared?.Invoke(Unit.Default);
            _onCountChanged?.Invoke(new CountChangedEvent(oldValues.Length, 0));
        }
        
        // Observables
        #region Observables
        public override IObservable<CountChangedEvent> ObserveCountChanged()
        {
            return Observable.FromEvent<CountChangedEvent>(
                response => _onCountChanged += response,
                response => _onCountChanged -= response
            );
        }

        public override IObservable<AddedEvent<T>> ObserveAdd()
        {
            return Observable.FromEvent<AddedEvent<T>>(
                response => _onElementAdded += response,
                response => _onElementAdded -= response
            );
        }

        public override IObservable<RemovedEvent<T>> ObserveRemove()
        {
            return Observable.FromEvent<RemovedEvent<T>>(
                response => _onElementRemoved += response,
                response => _onElementRemoved -= response
            );
        }
        
        public override IObservable<ChangedEvent<T>> ObserveChange()
        {
            return Observable.FromEvent<ChangedEvent<T>>(
                response => _onElementChanged += response,
                response => _onElementChanged -= response
            );
        }

        public override IObservable<Unit> ObserveClear()
        {
            return Observable.FromEvent<Unit>(
                response => _onCleared += response,
                response => _onCleared -= response
            );
        }
        #endregion
    }
}