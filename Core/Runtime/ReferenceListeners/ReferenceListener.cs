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
        [SerializeField] private float _responseDelay;
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
            
            if (_responseDelay > 0f)
                _disposable = _variableRef.Delay(TimeSpan.FromSeconds(_responseDelay)).Subscribe(_response.Invoke);
            else
                _disposable = _variableRef.Subscribe(_response.Invoke);
        }
        protected virtual void OnDisable()
        {
            _disposable?.Dispose();
            _disposable = null;
        }
    }
}