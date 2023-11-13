using System;
using System.Collections;
using NUnit.Framework;
using ScriptableObjectArchitecture.Variables;
using UniRx;
using UnityEngine;
using UnityEngine.TestTools;

namespace ScriptableObjectArchitecture.Tests.Variables
{
    public class VariableSubscriptionTests
    {
        // Bool
        [UnityTest]
        public IEnumerator BoolVariableSubscription() => VariableSubscriptionTest(false, true);
        [UnityTest]
        public IEnumerator BoolVariableSubscriptionReversed() => VariableSubscriptionTest(true, false);
        
        // String
        [UnityTest]
        public IEnumerator StringVariableSubscription() => VariableSubscriptionTest("Hello", "World!");
        [UnityTest]
        public IEnumerator StringVariableSubscriptionNull() => VariableSubscriptionTest(null, "World!");
        [UnityTest]
        public IEnumerator StringVariableSubscriptionNullReversed() => VariableSubscriptionTest("Hello", null);
        
        // GameObject
        [UnityTest]
        public IEnumerator GameObjectVariableSubscription() => VariableSubscriptionTest(null, new GameObject());
        [UnityTest]
        public IEnumerator GameObjectVariableSubscriptionReversed() => VariableSubscriptionTest(new GameObject(), null);
        
        private IEnumerator VariableSubscriptionTest<T>(T defaultValue, T newValue)
        {
            Variable<T> variable = (Variable<T>)ScriptableObject.CreateInstance(ConcreteTypesFinder.GetConcreteType<Variable<T>>());
            Assert.IsNotNull(variable);
            variable.name = $"Test Variable ({typeof(T).Name})";

            variable.Value = defaultValue;
            
            // Test subscription callback raise
            // -> callback should be raised
            int count = 0;
            IDisposable subscription = variable.Subscribe(_ => count++);
            int expectedCount = 1;
            Assert.AreEqual(count, expectedCount);
            
            // Test value change
            // -> callback should be raised
            variable.Value = newValue;
            expectedCount++;
            Assert.AreEqual(count, expectedCount);

            // Test value changes to the same value
            // -> callback shouldn't be raised
            variable.Value = newValue;
            Assert.AreEqual(count, expectedCount);

            // Test set value and force notify
            // -> callback should be raised
            variable.SetValueAndForceNotify(newValue);
            expectedCount++;
            Assert.AreEqual(count, expectedCount);
            
            // Test dispose
            // -> Callback shouldn't be raised
            subscription.Dispose();
            variable.Value = defaultValue;
            Assert.AreEqual(count, expectedCount);

            subscription = null;
            yield return null;
        }

    }
}