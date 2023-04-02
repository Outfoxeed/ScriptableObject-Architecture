namespace ScriptableObjectArchitecture.Variables
{
    public interface IVariable<T> : IReadOnlyVariable<T>
    {
        public T SetValue(T value);
        public T SetValueAndForceNotify(T value);
    }
}