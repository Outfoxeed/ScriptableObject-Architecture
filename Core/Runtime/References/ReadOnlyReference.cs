using System;
using System.ComponentModel;
using ScriptableObjectArchitecture.Constants;
using ScriptableObjectArchitecture.Instancers;
using ScriptableObjectArchitecture.Variables;
using UnityEngine;

namespace ScriptableObjectArchitecture.References
{
    [System.Serializable]
    public class ReadOnlyReference<T> : IReadOnlyReference<T>
    {
        [field: SerializeField] public ReferenceUsage ReferenceUsage { get; private set; }
        [SerializeField] protected T _value;
        [SerializeField] protected Variable<T> _variable;
        [SerializeField] protected VariableInstancer<T> _variableInstancer;
        [SerializeField] protected Constant<T> _constant;
        
        public virtual IDisposable Subscribe(IObserver<T> observer)
        {
            switch (ReferenceUsage)
            {
                case ReferenceUsage.Value:
                    throw new Exception("Cannot subscribe to a value");
                case ReferenceUsage.Variable:
                    return _variable.Subscribe(observer);
                case ReferenceUsage.Instancer:
                    return _variableInstancer.Subscribe(observer);
                case ReferenceUsage.Constant:
                    observer.OnNext(_constant.Value);
                    Debug.LogWarning($"Cannot subscribe to a constant. The callback has still been called");
                    throw new Exception("Cannot subscribe to a constant");
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public T Value => GetValue();
        protected T GetValue() => ReferenceUsage switch
        {
            ReferenceUsage.Value => _value,
            ReferenceUsage.Variable => _variable.Value,
            ReferenceUsage.Instancer => _variableInstancer.Value,
            ReferenceUsage.Constant => _constant.Value,
            _ => throw new InvalidEnumArgumentException()
        };

        public bool IsValid() => ReferenceUsage switch
        {
            ReferenceUsage.Value => true,
            ReferenceUsage.Variable => _variable != null,
            ReferenceUsage.Instancer => _variableInstancer != null,
            ReferenceUsage.Constant => _constant != null,
            _ => throw new InvalidEnumArgumentException()
        };

        public bool HasValue => true;
    }
}