using UniRx;

namespace ScriptableObjectArchitecture.References
{
    public interface IReadOnlyReference<T> : IReadOnlyReactiveProperty<T>
    {
        bool IsValid();
    }
}