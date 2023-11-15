using ScriptableObjectArchitecture.References;
using UnityEngine;

namespace ScriptableObjectArchitecture.ReferenceSetters
{
    public abstract class ReferenceSetter<T> : MonoBehaviour, IReferenceSetter<T>
    {
        [SerializeField] private SetTime _setTime = SetTime.Start;
        [SerializeField] private Reference<T> _referenceToSet;
        [SerializeField] private ReadOnlyReference<T> _setValue;
        [SerializeField] private bool _forceNotify;
        
        public enum SetTime
        {
            Awake,
            OnEnable,
            Start,
            Never
        }
        
        protected virtual void Awake()
        {
            if (_setTime is not SetTime.Awake)
            {
                return;
            }
            
            SetReferenceValue();
        }
        
        protected virtual void OnEnable()
        {
            if (_setTime is not SetTime.OnEnable)
            {
                return;
            }
            
            SetReferenceValue();
        }
        
        protected virtual void Start()
        {
            if (_setTime is not SetTime.Start)
            {
                return;
            }
            
            SetReferenceValue();
        }

        /// <summary>
        /// Set _referenceToSet's value to _setValue's value.
        /// Called on Start, Awake, or Enable depending on initializationTime value.
        /// </summary>
        public void SetReferenceValue() => SetReferenceValue(_setValue.Value);
        public void SetReferenceValue(T value)
        {
            if (_forceNotify)
            {
                _referenceToSet.SetValueAndForceNotify(_setValue.Value);
                return;
            }
            _referenceToSet.Value = _setValue.Value;
        }
    }
}