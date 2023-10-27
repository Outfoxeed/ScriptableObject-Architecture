namespace ScriptableObjectArchitecture.Constants
{
    public interface IConstant<out T>
    {
        public T Value { get; }
    }
}