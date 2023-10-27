using System;
using ScriptableObjectArchitecture.GameEvents;
using UniRx;
using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectArchitecture.GameEventListeners
{
    public class GameEventListener<T> : MonoBehaviour, IGameEventListener<T>
    {
        [SerializeField] private ReadOnlyGameEvent<T> _gameEvent;
        [SerializeField] private UnityEvent<T> _response;
        private IDisposable _disposable;
        
        protected virtual void OnEnable()
        {
            _disposable?.Dispose();
            _disposable = _gameEvent.Subscribe(_response.Invoke);
        }
        protected virtual void OnDisable()
        {
            _disposable?.Dispose();
            _disposable = null;
        }
    }
}