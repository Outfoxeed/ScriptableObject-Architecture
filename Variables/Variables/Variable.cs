using System;
using ScriptableObjectArchitecture.Subscriptions;
using UnityEngine;

namespace ScriptableObjectArchitecture.Variables
{
    /// <summary>
    /// ScriptableObject with Generic Read-Write value on which we can subscribe to
    /// </summary>
    /// <typeparam name="T">object</typeparam>
    public abstract class Variable<T> : ReadOnlyVariable<T>, IVariable<T>
    {
#if UNITY_EDITOR
        [SerializeField] private bool _debugMode;
        [SerializeField, Multiline] private string _description;
#endif
        [SerializeField] private T _value;

        private SubscriptionDictionary<T> _subscriptions = new();

        public new T Value
        {
            get => GetValue();
            set => SetValue(value);
        }
        
        #region Read
        public override T GetValue()
        {
            return _value;
        }
        public override IDisposable Subscribe(object subscriber, string subscriptionName, Action<T> callback, bool raiseCallback = true)
        {
            IDisposable subscribeDisposable = _subscriptions.AddSubscription(subscriber, subscriptionName, callback);
            DevelopmentLog($"'{this.name}' variable received a new subscription from '{subscriber}' (subscription name: '{subscriptionName}')\n{this}");
            if (raiseCallback)
            {
                callback?.Invoke(_value);
            }
            return subscribeDisposable;
        }
        public override IDisposable Subscribe(object subscriber, string subscriptionName, Action callback, bool raiseCallback = true)
        {
            return Subscribe(subscriber, subscriptionName, _ => callback?.Invoke(), raiseCallback);
        }
        #endregion

        #region Write
        public T SetValue(T value)
        {
            if (_value.Equals(value))
            {
                return _value;
            }
            DevelopmentLog($"'{this.name}' value set to {value}");
            return Internal_SetValueAndNotify(value);
        }

        public T SetValueAndForceNotify(T value)
        {
            DevelopmentLog($"'{this.name}' value set to {value}. <color=yellow>Notify forced</color>");
            return Internal_SetValueAndNotify(value);
        }

        private T Internal_SetValueAndNotify(T value)
        {
            _value = value;
            _subscriptions.RaiseAllSubscriptions(_value);
            return _value;
        }
        #endregion

#if UNITY_EDITOR
        private void OnValidate()
        {
            Internal_SetValueAndNotify(_value);
        }
#endif

        private void DevelopmentLog(string message)
        {
#if UNITY_EDITOR
            if (_debugMode)
            {
#if UNITY_EDITOR || DEVELOPMENT_BUILD
                Debug.Log(message);
#endif
            }
#endif
        }

        public override string ToString()
        {
            return $"'{this.name}' variable: {{value: {_value}; subcriptions: \n{_subscriptions}\n}}";
        }
    }
}