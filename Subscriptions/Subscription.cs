using System;
using UnityEngine;

namespace ScriptableObjectArchitecture.Subscriptions
{
    public struct Subscription<T> : IDisposable, ISubscription<T>
    {
        public string Name => _name;
        private string _name;
        
        private readonly Action<T> _callback;
        private object _subscriber;
        private ISubscriptionDictionary<T> _container;

        public Subscription(object subscriber, string name, Action<T> callback, ISubscriptionDictionary<T> container)
        {
            _name = name;
            _callback = callback;
            _subscriber = subscriber;
            _container = container;
        }

        public void Dispose()
        {
            if (_container == null)
            {
                Debug.LogWarning($"Subscription named '{_name}' already disposed. Method ignored");
                return;
            }
            _container.RemoveSubscription(_subscriber, _name);
            _subscriber = null;
            _container = null;
        }

        public void Raise(T parameter)
        {
            _callback?.Invoke(parameter);
        }

        public string ToString(bool includeSubscriber = false)
        {
            return string.Concat($"{{name: {_name}", includeSubscriber ? $"; owner: {_subscriber}" : "", "}}");
        }
    }
}