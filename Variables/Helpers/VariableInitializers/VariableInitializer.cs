using UnityEngine;

namespace ScriptableObjectArchitecture.Variables.Helpers.VariableInitializers
{
    /// <summary>
    /// Monobehaviour intializing when wanted
    /// a value of a VariableReference to another VariableReference's value
    /// </summary>
    /// <typeparam name="T">Type of VariableReferences value</typeparam>
    [DefaultExecutionOrder(-1)]
    public abstract class VariableInitializer<T> : MonoBehaviour
    {
        [SerializeField] private InitializeTime _initializationTime = InitializeTime.Start;
        [SerializeField] private VariableReference<T> _variableToInitialize;
        [SerializeField] private ReadOnlyVariableReference<T> _initializeValue;
        [SerializeField] private bool _forceNotify;
        public enum InitializeTime
        {
            Awake,
            OnEnable,
            Start,
            Never
        }

        protected virtual void Awake()
        {
            if (_initializationTime is not InitializeTime.Awake)
            {
                return;
            }
            InitializeVariable();
        }

        protected virtual void OnEnable()
        {
            if (_initializationTime is not InitializeTime.OnEnable)
            {
                return;
            }
            InitializeVariable();
        }

        protected virtual void Start()
        {
            if (_initializationTime is not InitializeTime.Start)
            {
                return;
            }
            InitializeVariable();
        }

        /// <summary>
        /// Set variableToInitialize's value to initializeValue's value.
        /// Called on Start, Awake, or Enable depending on initializationTime value.
        /// </summary>
        public void InitializeVariable()
        {
            if (_forceNotify)
            {
                _variableToInitialize.SetValueAndForceNotify(_initializeValue.Value);
                return;
            }
            _variableToInitialize.Value = _initializeValue.Value;
        }
    }
}