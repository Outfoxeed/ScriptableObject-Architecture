using ScriptableObjectArchitecture.Subscriptions;

namespace ScriptableObjectArchitecture.GameEvents.Helpers.GameEventRaisers
{
    public interface IGameEventRaiser<T>
    {
        /// <summary>
        /// Execute a generic GameEvent with a parameter
        /// </summary>
        /// <param name="parameter">Parameter given to the GameEvent when executed</param>
        public void RaiseGameEvent(T parameter);
    }
    public interface IGameEventRaiser : IGameEventRaiser<Empty>
    {
        /// <summary>
        /// Execute a GameEvent
        /// </summary>
        public void RaiseGameEvent();
    }
}