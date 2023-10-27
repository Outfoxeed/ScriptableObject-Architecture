using UniRx;

namespace ScriptableObjectArchitecture.Variables
{
    public interface IReadOnlyVariable<T> : IReadOnlyReactiveProperty<T>
    {
    }
}