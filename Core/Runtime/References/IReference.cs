using UniRx;

namespace ScriptableObjectArchitecture.References
{
    public interface IReference<T> : IReactiveProperty<T>
    {
        public void SetValueAndForceNotify(T value);
    }
}