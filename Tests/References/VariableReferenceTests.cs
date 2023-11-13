using System;
using NUnit.Framework;
using ScriptableObjectArchitecture.References;
using ScriptableObjectArchitecture.Variables;
using UniRx;
using UnityEngine;

namespace ScriptableObjectArchitecture.Tests.References
{
    public class VariableReferenceTests
    {
        // Bool
        [Test]
        public void BoolVariableReferenceTest() => VariableReferenceTest(false, true);
        [Test]
        public void BoolVariableReferenceTestReversed() => VariableReferenceTest(true, false);

        // String
        [Test]
        public void StringVariableReferenceTest() => VariableReferenceTest("Hello", "World!");
        [Test]
        public void StringVariableReferenceTestNull() => VariableReferenceTest(null, "World!");
        [Test]
        public void StringVariableReferenceTestNullReversed() => VariableReferenceTest("Hello", null);
        
        // GameObject
        [Test]
        public void GameObjectVariableReferenceTest() => VariableReferenceTest(null, new GameObject());
        [Test]
        public void GameObjectVariableReferenceTestReversed() => VariableReferenceTest(new GameObject(), null);
        
        // Vector3
        [Test]
        public void Vector3VariableReferenceTest() => VariableReferenceTest(Vector3.zero, Vector3.one);
        [Test]
        public void Vector3VariableReferenceTestReversed() => VariableReferenceTest(Vector3.one, Vector3.zero);
        
        private void VariableReferenceTest<T>(T defaultValue, T newValue)
        {
            Variable<T> variable = (Variable<T>)ScriptableObject.CreateInstance(ConcreteTypesFinder.GetConcreteType<Variable<T>>());
            Assert.IsNotNull(variable);
            variable.name = $"Test Variable ({typeof(T)})";
            variable.Value = defaultValue;
            
            Reference<T> reference = new Reference<T>(variable);

            // Test reference link with variable
            Assert.AreEqual(reference.Value, defaultValue);
            Assert.AreEqual(variable.Value, reference.Value);

            // Test value change from variable
            variable.Value = newValue;
            Assert.AreEqual(reference.Value, newValue);
            Assert.AreEqual(reference.Value, variable.Value);
            
            // Test value change from reference
            reference.Value = defaultValue;
            Assert.AreEqual(reference.Value, defaultValue);
            Assert.AreEqual(reference.Value, variable.Value);
            
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
            
            // Test value change from variable after subscription
            // -> callback should be raised
            variable.Value = defaultValue;
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
            variable.Value = defaultValue;
            Assert.AreEqual(count, expectedCount);
        }
    }
}