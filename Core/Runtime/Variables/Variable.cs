using System;
using ScriptableObjectArchitecture.References;
using UniRx;
using UnityEngine;
using Logger = ScriptableObjectArchitecture.Utils.Logger;

namespace ScriptableObjectArchitecture.Variables
{
    /// <summary>
    /// ScriptableObject with Generic Read-Write value on which we can subscribe to
    /// </summary>
    /// <typeparam name="T">object</typeparam>
    public abstract class Variable<T> : ReadOnlyVariable<T>, IVariable<T>
    {
        [SerializeField] private ReactiveProperty<T> _property = new();
        [SerializeField] private ReadOnlyReference<T> _defaultValue = new();

        public new T Value
        {
            get => _property.Value;
            set
            {
                Logger.Instance?.Log($"'{this.name}' value set to {value}", DebugMode);
                _property.Value = value;
            }
        }

        protected override T GetValue() => _property.Value;
        public T SetValueAndForceNotify(T value)
        {
            Logger.Instance?.Log($"'{this.name}' value set to {value}. <color=yellow>Notify forced</color>", DebugMode);
            _property.SetValueAndForceNotify(value);
            return _property.Value;
        }

        public override IDisposable Subscribe(IObserver<T> observer)
        {
            Logger.Instance?.Log($"'{this.name}' variable received a new subscription \nvalue: {_property.Value}", DebugMode);
            return _property.Subscribe(observer);
        }

        public void Reset()
        {
            _property.Value = _defaultValue.Value;
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            _property.SetValueAndForceNotify(_property.Value);
        }
#endif

        public override string ToString()
        {
            return $"'{this.name}' variable: {{value: {_property.Value}}}";
        }
    }
}