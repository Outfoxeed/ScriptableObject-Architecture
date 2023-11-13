using System;
using ScriptableObjectArchitecture.Constants;
using ScriptableObjectArchitecture.Instancers;
using ScriptableObjectArchitecture.Variables;
using UnityEngine;

namespace ScriptableObjectArchitecture.References
{
    [System.Serializable]
    public class Reference<T> : ReadOnlyReference<T>, IReference<T>
    {
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
                        _variableInstancer.Value = value;
                        break;
                    case ReferenceUsage.Constant:
                        throw new Exception("Cannot change the value of a constant");
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
        
        public Reference(T value)
        {
            ReferenceUsage = ReferenceUsage.Value;
            _value = value;
        }

        public Reference(Variable<T> variable)
        {
            ReferenceUsage = ReferenceUsage.Variable;
            _variable = variable;
        }

        public Reference(VariableInstancer<T> variableInstancer)
        {
            ReferenceUsage = ReferenceUsage.Instancer;
            _variableInstancer = variableInstancer;
        }

        public Reference(Constant<T> constant)
        {
            ReferenceUsage = ReferenceUsage.Constant;
            _constant = constant;
        }
    }
}