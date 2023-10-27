using System;
using ScriptableObjectArchitecture.Variables;
using UnityEngine;

namespace ScriptableObjectArchitecture.References
{
    [System.Serializable]
    public class Reference<T> : ReadOnlyReference<T>, IReference<T>, ISerializationCallbackReceiver
    {
        [SerializeField] private Variable<T> _variable;
        public new T Value
        {
            get => GetValue();
            set
            {
                switch (ReferenceUsage)
                {
                    case ReferenceUsage.Value:
                        _value = value;
                        break;
                    case ReferenceUsage.Variable:
                        _variable.Value = value;
                        break;
                    case ReferenceUsage.Instancer:
                        throw new NotImplementedException();
                    case ReferenceUsage.Constant:
                        throw new Exception("Cannot change the value of a constant");
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        public void OnBeforeSerialize()
        {
            _readOnlyVariable = _variable;
        }

        public void OnAfterDeserialize()
        {
        }
    }
}