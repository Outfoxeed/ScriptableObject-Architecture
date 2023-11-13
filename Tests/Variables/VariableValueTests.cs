using System.Collections;
using NUnit.Framework;
using ScriptableObjectArchitecture.Instancers;
using ScriptableObjectArchitecture.Variables;
using UnityEngine;
using UnityEngine.TestTools;

namespace ScriptableObjectArchitecture.Tests.Variables
{
    public class VariableValueTests
    {
        // Bool
        [UnityTest]
        public IEnumerator BoolVariableValueChange() => VariableValueChangesTest(false, true);
        [UnityTest]
        public IEnumerator BoolVariableValueChangeReversed() => VariableValueChangesTest(true, false);
        
        // String
        [UnityTest]
        public IEnumerator StringVariableValueChange() => VariableValueChangesTest("Hello", "World!");
        [UnityTest]
        public IEnumerator StringVariableValueChangeNull() => VariableValueChangesTest(null, "World!");
        [UnityTest]
        public IEnumerator StringVariableValueChangeNullReversed() => VariableValueChangesTest("Hello", null);
        
        // GameObject
        [UnityTest]
        public IEnumerator GameObjectVariableValueChange() => VariableValueChangesTest(null, new GameObject());
        [UnityTest]
        public IEnumerator GameObjectVariableValueChangeResversed() => VariableValueChangesTest(new GameObject(), null);
        
        private IEnumerator VariableValueChangesTest<T>(T defaultValue, T newValue)
        {
            var go = new GameObject();
            var variableInstancer = (VariableInstancer<T>)go.AddComponent(ConcreteTypesFinder.GetConcreteType<VariableInstancer<T>>());
            
            Assert.IsNotNull(variableInstancer);

            Variable<T> variable = variableInstancer.So;
            Assert.IsNotNull(variable);

            variable.Value = defaultValue;
            Assert.AreEqual(variable.Value, defaultValue);

            variable.Value = newValue;
            Assert.AreEqual(variable.Value, newValue);
            
            yield return null;
        }
    }
}