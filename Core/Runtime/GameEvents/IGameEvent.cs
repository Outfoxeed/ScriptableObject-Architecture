namespace ScriptableObjectArchitecture.GameEvents
{
    public interface IGameEvent
    {
#if UNITY_EDITOR
        bool RaiseWithDebugParameter();
#endif
    }
    public interface IGameEvent<T> : IGameEvent, IReadOnlyGameEvent<T>
    {
        bool Raise(T parameter);
    }
}