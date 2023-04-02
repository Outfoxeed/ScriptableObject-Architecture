using System;
using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectArchitecture.GameEvents.Helpers.GameEventListeners
{
    public class GameEventListener<T> : MonoBehaviour, IGameEventListener<T>
    {
        [SerializeField] private string _responseName;
        [SerializeField] private GameEvent<T> _gameEvent;
        [SerializeField] private UnityEvent<T> _response;
        private IDisposable _disposable;
        
        protected virtual void OnEnable()
        {
            _disposable?.Dispose();
            _disposable = _gameEvent.Subscribe(this, _responseName, parameter => _response.Invoke(parameter));
        }
        protected virtual void OnDisable()
        {
            _disposable?.Dispose();
            _disposable = null;
        }
    }
}