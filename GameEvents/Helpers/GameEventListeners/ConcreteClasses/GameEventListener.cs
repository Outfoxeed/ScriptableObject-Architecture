using System;
using ScriptableObjectArchitecture.GameEvents.ConcreteClasses;
using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectArchitecture.GameEvents.Helpers.GameEventListeners.ConcreteClasses
{
    [AddComponentMenu("Game Events/Game Events Listeners/Game Event Listener")]
    public class GameEventListener : MonoBehaviour, IGameEventListener
    {
        [SerializeField] private string _responseName;
        [SerializeField] private GameEvent _gameEvent;
        [SerializeField] private UnityEvent _response;
        private IDisposable _disposable;

        protected virtual void OnEnable()
        {
            _disposable?.Dispose();
            _disposable = _gameEvent.Subscribe(this, _responseName, () => _response.Invoke());
        }
        protected virtual void OnDisable()
        {
            _disposable?.Dispose();
            _disposable = null;
        }
    }
}