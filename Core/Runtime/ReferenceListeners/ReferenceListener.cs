using System;
using ScriptableObjectArchitecture.References;
using UniRx;
using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectArchitecture.ReferenceListeners
{
    public abstract class ReferenceListener<T> : MonoBehaviour, IReferenceListener<T>
    {
        [SerializeField] private Reference<T> _variableRef;
        [SerializeField] private UnityEvent<T> _response;
        private IDisposable _disposable;
        
        protected virtual void OnEnable()
        {
            if (!_variableRef.IsValid())
            {
                Debug.LogError($"Given variable reference is not valid. Cancelled subscription", this);
                return;
            }
            
            _disposable?.Dispose();
            _disposable = _variableRef.Subscribe(_response.Invoke);
        }
        protected virtual void OnDisable()
        {
            _disposable?.Dispose();
            _disposable = null;
        }
    }
}