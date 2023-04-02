
namespace ScriptableObjectArchitecture.GameEvents
{
    public interface IGameEvent : IReadOnlyGameEvent
    {
        public bool Raise(object sender);
    }
    public interface IGameEvent<T> : IGameEvent, IReadOnlyGameEvent<T>
    {
        public bool Raise(object sender, T parameter);
    }
}