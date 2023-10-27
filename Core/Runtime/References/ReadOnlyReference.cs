using System;
using System.ComponentModel;
using ScriptableObjectArchitecture.Constants;
using ScriptableObjectArchitecture.VariableInstancers;
using ScriptableObjectArchitecture.Variables;
using UnityEngine;
using UnityEngine.Serialization;

namespace ScriptableObjectArchitecture.References
{
    [System.Serializable]
    public class ReadOnlyReference<T> : IReadOnlyReference<T>
    {
        [field: SerializeField] public ReferenceUsage ReferenceUsage { get; private set; }
        [SerializeField] protected T _value;
        [SerializeField] protected ReadOnlyVariable<T> _readOnlyVariable;
        [SerializeField] protected VariableInstancer<T> _variableInstancer;
        [SerializeField] protected Constant<T> _constant;
        
        public virtual IDisposable Subscribe(IObserver<T> observer)
        {
            switch (ReferenceUsage)
            {
                case ReferenceUsage.Value:
                    throw new Exception("Cannot subscribe to a value");
                case ReferenceUsage.Variable:
                    return _readOnlyVariable.Subscribe(observer);
                case ReferenceUsage.Instancer:
                    //TODO:
                    throw new NotImplementedException();
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
            ReferenceUsage.Variable => _readOnlyVariable.Value,
            ReferenceUsage.Instancer => throw new NotImplementedException(),
            ReferenceUsage.Constant => _constant.Value,
            _ => throw new InvalidEnumArgumentException()
        };

        public bool HasValue => true;
    }
}