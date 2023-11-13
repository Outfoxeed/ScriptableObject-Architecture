namespace ScriptableObjectArchitecture.RuntimeSets
{
    public interface IRuntimeSet : IReadOnlyRuntimeSet
    {
        
    }
    
    public interface IRuntimeSet<T> : IReadOnlyRuntimeSet<T>, IRuntimeSet
    {
        int IndexOf(T item);
        void Insert(int index, T item);
        void RemoveAt(int index);
        bool Remove(T item);
    }
}