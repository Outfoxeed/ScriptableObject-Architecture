namespace ScriptableObjectArchitecture.ReferenceSetters
{
    public interface IReferenceSetter
    {
        void SetReferenceValue();
    }

    public interface IReferenceSetter<T> : IReferenceSetter
    {
        void SetReferenceValue(T value);
    }
}