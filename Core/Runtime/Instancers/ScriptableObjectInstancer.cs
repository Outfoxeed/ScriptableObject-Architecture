using UnityEngine;

namespace ScriptableObjectArchitecture.Instancers
{
    /// <summary>
    /// MonoBehaviour class instantiating a ScriptableObject at Awake
    /// </summary>
    /// <typeparam name="T">Type of the ScriptableObject to instantiate</typeparam>
    [DefaultExecutionOrder(-100)]
    public abstract class ScriptableObjectInstancer<T> : MonoBehaviour, IGetSo<T> where T : ScriptableObject
    {
        public T So { get; private set; }
        ScriptableObject IGetSo.So => So;

        private void Awake()
        {
            So = (T)ScriptableObject.CreateInstance(ConcreteTypesFinder.GetConcreteType<T>());
        }
    }
}