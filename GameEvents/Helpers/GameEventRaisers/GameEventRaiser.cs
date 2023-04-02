using UnityEngine;

namespace ScriptableObjectArchitecture.GameEvents.Helpers.GameEventRaisers
{
    public abstract class GameEventRaiser<T> : MonoBehaviour, IGameEventRaiser<T>
    {
        [SerializeField] protected GameEvent<T> _gameEvent;
        
        public virtual void RaiseGameEvent(T parameter)
        {
            _gameEvent.Raise(parameter);
        }
    }
}