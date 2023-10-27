using UniRx;

namespace ScriptableObjectArchitecture.Variables
{
    public interface IVariable<T> : IReadOnlyVariable<T>, IReactiveProperty<T>
    {
        T SetValueAndForceNotify(T value);
    }
}