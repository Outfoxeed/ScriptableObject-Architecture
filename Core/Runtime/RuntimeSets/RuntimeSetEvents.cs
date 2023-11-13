namespace ScriptableObjectArchitecture.RuntimeSets
{
    public struct AddedEvent<T>
    {
        public T Value;
        public int Index;

        public AddedEvent(T value, int index)
        {
            Value = value;
            Index = index;
        }
    }
    
    public struct RemovedEvent<T>
    {
        public T Value;
        public int Index;

        public RemovedEvent(T value, int index)
        {
            Value = value;
            Index = index;
        }
    }
    
    public struct ChangedEvent<T>
    {
        public T OldValue;
        public T NewValue;

        public ChangedEvent(T oldValue, T newValue)
        {
            OldValue = oldValue;
            NewValue = newValue;
        }
    }

    public struct CountChangedEvent
    {
        public int OldCount;
        public int NewCount;

        public CountChangedEvent(int oldCount, int newCount)
        {
            OldCount = oldCount;
            NewCount = newCount;
        }
    }
}