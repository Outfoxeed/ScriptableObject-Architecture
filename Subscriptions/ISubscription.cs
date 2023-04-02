namespace ScriptableObjectArchitecture.Subscriptions
{
    public interface ISubscription<in T>
    {
        public string Name { get; }
        public void Raise(T parameter);
    }
}