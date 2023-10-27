
namespace ScriptableObjectArchitecture.GameEvents
{
    public interface IGameEvent<T> : IReadOnlyGameEvent<T>
    {
        public bool Raise(T parameter);
    }
}