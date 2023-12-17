using ScriptableObjectArchitecture.RuntimeSets;
using UnityEngine;

namespace ScriptableObjectArchitecture.RuntimeSetInjectors
{
    /// <summary>
    /// MonoBehaviour class adding an element to a RuntimeSet OnEnable and removing it OnDisable
    /// </summary>
    /// <typeparam name="T">Type of the element to inject in the runtime set</typeparam>
    public abstract class RuntimeSetInjector<T> : MonoBehaviour
    {
        [SerializeField] private T _elementToInject;
        [SerializeField] private RuntimeSet<T> _runtimeSet;

        private void OnEnable()
        {
            _runtimeSet.Add(_elementToInject);
        }

        private void OnDisable()
        {
            _runtimeSet.Remove(_elementToInject);
        }
    }
}