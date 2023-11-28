using System;
using ScriptableObjectArchitecture.Constants;
using ScriptableObjectArchitecture.VariableInstancers;
using ScriptableObjectArchitecture.Variables;
using UnityEngine;
using Logger = ScriptableObjectArchitecture.Utils.Logger;

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
        
        public void SetValueAndForceNotify(T value)
        {
            switch (ReferenceUsage)
            {
                case ReferenceUsage.Value:
                    Logger.Instance?.Log(Logger.LogType.Warning,
                        $"Cannot force notify on a {ReferenceUsage.ToString().Split('.')[^1]}. " + 
                        "The value has still been changed");
                    _value = value;
                    break;
                case ReferenceUsage.Variable:
                    _variable.SetValueAndForceNotify(value);
                    break;
                case ReferenceUsage.Instancer:
                    _variableInstancer.SetValueAndForceNotify(value);
                    break;
                case ReferenceUsage.Constant:
                    throw new Exception("Cannot change the value of a constant");
                default:
                    throw new ArgumentException();
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