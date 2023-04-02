using System;
using UnityEngine;

namespace ScriptableObjectArchitecture.Variables
{
    /// <summary>
    /// Reference to a Generic Read-Write Variable with the possibility to use a custom value
    /// instead of the variable.
    /// </summary>
    /// <typeparam name="T">object</typeparam>
    [Serializable]
    public class VariableReference<T> : ReadOnlyVariableReference<T>, IVariable<T>
    {
        private const string LOG_PREFIX = "[VARIABLE REFERENCE]";

        protected override IReadOnlyVariable<T> ReadOnlyVariable => _variable;
        [SerializeField] private Variable<T> _variable;

        public new T Value
        {
            get => GetValue();
            set => SetValue(value);
        }

        public T SetValue(T value)
        {
            if (_useCustomValue)
            {
                _customValue = value;
                return value;
            }
            _variable.Value = value;
            return value;
        }
        public T SetValueAndForceNotify(T value)
        {
            if (_useCustomValue)
            {
                _customValue = value;
                Debug.LogWarning($"{LOG_PREFIX} Can't force notify when using a custom value");
                return value;
            }
            _variable.SetValueAndForceNotify(value);
            return value;
        }
    }
}