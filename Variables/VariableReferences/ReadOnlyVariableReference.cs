using System;
using UnityEngine;

namespace ScriptableObjectArchitecture.Variables
{
    /// <summary>
    /// Reference to a Generic Read-Only Variable with the possibility to use a custom value
    /// instead of the variable.
    /// </summary>
    /// <typeparam name="T">object</typeparam>
    [Serializable]
    public class ReadOnlyVariableReference<T> : IReadOnlyVariable<T>
    {
        private const string LOG_PREFIX = "[READ ONLY VARIABLE REFERENCE]";
        
        protected virtual IReadOnlyVariable<T> ReadOnlyVariable => _readOnlyVariable;
        [SerializeField] private ReadOnlyVariable<T> _readOnlyVariable;
        [SerializeField] protected bool _useCustomValue;
        [SerializeField] protected T _customValue;

        public T Value
        {
            get => GetValue();
        }
        
        public virtual T GetValue()
        {
            if (_useCustomValue)
            {
                return _customValue;
            }
            return ReadOnlyVariable.GetValue();
        }

        public virtual IDisposable Subscribe(object subscriber, string subscriptionName, Action<T> callback, bool raiseCallback = true)
        {
            if (_useCustomValue)
            {
                Debug.LogWarning($"{LOG_PREFIX} Cannot subscribe to a custom value");
                return null;
            }
            return ReadOnlyVariable.Subscribe(subscriber, subscriptionName, callback, raiseCallback);
        }

        public IDisposable Subscribe(object subscriber, string subscriptionName, Action callback, bool raiseCallback = true)
        {
            return Subscribe(subscriber, subscriptionName, callback);
        }
    }
}