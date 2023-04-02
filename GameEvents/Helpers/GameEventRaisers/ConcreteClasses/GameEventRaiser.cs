using ScriptableObjectArchitecture.GameEvents.ConcreteClasses;
using ScriptableObjectArchitecture.Subscriptions;
using UnityEngine;

namespace ScriptableObjectArchitecture.GameEvents.Helpers.GameEventRaisers
{
    [AddComponentMenu("Game Events/Game Events Raisers/Game Event Raiser")]
    public class GameEventRaiser : MonoBehaviour, IGameEventRaiser
    {
        [SerializeField] protected GameEvent _gameEvent;

        public virtual void RaiseGameEvent()
        {
            _gameEvent.Raise(this);
        }
        public void RaiseGameEvent(Empty parameter)
        {
            RaiseGameEvent();
        }
    }
}