using System;
using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectArchitecture.Variables.Variables.Helpers.VariableListeners
{
    public abstract class VariableListener<T> : MonoBehaviour, IVariableListener<T>
    {
        [SerializeField] private string _name;
        [SerializeField] private VariableReference<T> _variableReference;
        [SerializeField] private UnityEvent<T> _response;
        private IDisposable _disposable;
        
        protected virtual void OnEnable()
        {
            _disposable?.Dispose();
            _disposable = _variableReference.Subscribe(this, _name, parameter => _response?.Invoke(parameter));
        }
        protected virtual void OnDisable()
        {
            _disposable?.Dispose();
            _disposable = null;
        }
    }
}