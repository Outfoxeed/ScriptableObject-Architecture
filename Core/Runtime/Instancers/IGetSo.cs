using UnityEngine;

namespace ScriptableObjectArchitecture.Instancers
{
    public interface IGetSo
    {
        public ScriptableObject So { get; }
    }
    public interface IGetSo<T> : IGetSo where T : ScriptableObject
    {
        public new T So { get; }
    }
}