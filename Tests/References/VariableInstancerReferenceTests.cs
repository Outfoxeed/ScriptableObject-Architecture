using System;
using System.Collections;
using NUnit.Framework;
using ScriptableObjectArchitecture.VariableInstancers;
using ScriptableObjectArchitecture.References;
using ScriptableObjectArchitecture.Variables;
using UniRx;
using UnityEngine;
using UnityEngine.TestTools;

namespace ScriptableObjectArchitecture.Tests.References
{
    public class VariableInstancerReferenceTests
    {
        // Bool
        [UnityTest]
        public IEnumerator BoolVariableInstancerReferenceTest() => VariableInstancerReferenceTest(false, true);
        [UnityTest]
        public IEnumerator BoolVariableInstancerReferenceTestReversed() => VariableInstancerReferenceTest(true, false);

        // String
        [UnityTest]
        public IEnumerator StringVariableInstancerReferenceTest() => VariableInstancerReferenceTest("Hello", "World!");
        [UnityTest]
        public IEnumerator StringVariableInstancerReferenceTestNull() => VariableInstancerReferenceTest(null, "World!");
        [UnityTest]
        public IEnumerator StringVariableInstancerReferenceTestNullReversed() => VariableInstancerReferenceTest("Hello", null);
        
        // GameObject
        [UnityTest]
        public IEnumerator GameObjectVariableInstancerReferenceTest() => VariableInstancerReferenceTest(null, new GameObject());
        [UnityTest]
        public IEnumerator GameObjectVariableInstancerReferenceTestReversed() => VariableInstancerReferenceTest(new GameObject(), null);
        
        // Vector3
        [UnityTest]
        public IEnumerator Vector3VariableInstancerReferenceTest() => VariableInstancerReferenceTest(Vector3.zero, Vector3.one);
        [UnityTest]
        public IEnumerator Vector3VariableInstancerReferenceTestReversed() => VariableInstancerReferenceTest(Vector3.one, Vector3.zero);
        
        private IEnumerator VariableInstancerReferenceTest<T>(T defaultValue, T newValue)
        {
            var go = new GameObject($"Test VariableInstancer ({typeof(T)})");
            VariableInstancer<T> variableInstancer = (VariableInstancer<T>)go.AddComponent(ConcreteTypesFinder.GetConcreteType<VariableInstancer<T>>());
            Assert.IsNotNull(variableInstancer);
            variableInstancer.Value = defaultValue;
            
            Reference<T> reference = new Reference<T>(variableInstancer);

            // Test reference link with variable
            Assert.AreEqual(reference.Value, defaultValue);
            Assert.AreEqual(variableInstancer.Value, reference.Value);

            // Test value change from variable
            variableInstancer.Value = newValue;
            Assert.AreEqual(reference.Value, newValue);
            Assert.AreEqual(reference.Value, variableInstancer.Value);
            
            // Test value change from reference
            reference.Value = defaultValue;
            Assert.AreEqual(reference.Value, defaultValue);
            Assert.AreEqual(reference.Value, variableInstancer.Value);
            
            // Test subscription
            // -> callback should be raised
            int count = 0;
            IDisposable disposable = reference.Subscribe(_ => count++);
            int expectedCount = 1;
            Assert.AreEqual(count, expectedCount);
            
            // Test value change from reference after subscription
            // -> callback should be raised
            reference.Value = newValue;
            expectedCount++;
            Assert.AreEqual(count, expectedCount);
            
            // Test value change from variable instancer after subscription
            // -> callback should be raised
            variableInstancer.Value = defaultValue;
            expectedCount++;
            Assert.AreEqual(count, expectedCount);
            
            // Test SetValueAndForceNotify from reference after subscription
            // -> callback should be raised
            reference.SetValueAndForceNotify(defaultValue);
            expectedCount++;
            Assert.AreEqual(count, expectedCount);
            
            // Test SetValueAndForceNotify from variable instancer after subscription
            // -> callback should be raised
            variableInstancer.SetValueAndForceNotify(defaultValue);
            expectedCount++;
            Assert.AreEqual(count, expectedCount);
            
            // Test value change from refernce after dispose
            // -> callback should not be raised
            disposable.Dispose();
            disposable = null;
            reference.Value = newValue;
            Assert.AreEqual(count, expectedCount);
            
            // Test value change from variable after dispose
            // -> callback should not be raised
            variableInstancer.Value = defaultValue;
            Assert.AreEqual(count, expectedCount);

            yield return null;
        }
    }
}