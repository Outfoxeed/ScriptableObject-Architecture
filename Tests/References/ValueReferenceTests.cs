using System;
using System.Linq;
using System.Reflection;
using NUnit.Framework;
using ScriptableObjectArchitecture.Constants;
using ScriptableObjectArchitecture.References;
using ScriptableObjectArchitecture.Variables;
using UniRx;
using UnityEditor.VersionControl;
using UnityEngine;

namespace ScriptableObjectArchitecture.Tests.References
{
    public class ValueReferenceTests
    {
        // Bool
        [Test]
        public void BoolValueReferenceTest() => ValueReferenceTest(false, true);
        [Test]
        public void BoolValueReferenceTestReversed() => ValueReferenceTest(true, false);

        // String
        [Test]
        public void StringValueReferenceTest() => ValueReferenceTest("Hello","World!");
        [Test]
        public void StringValueReferenceTestNull() => ValueReferenceTest<string>(null, "World!");
        [Test]
        public void StringValueReferenceTestNullReversed() => ValueReferenceTest<string>("Hello", null);
        
        // GameObject
        [Test]
        public void GameObjectValueReferenceTest() => ValueReferenceTest<GameObject>(null, new GameObject());
        [Test]
        public void GameObjectValueReferenceTestNull() => ValueReferenceTest(new GameObject(), null);
        
        // Vector3
        [Test]
        public void Vector3ValueReferenceTest() => ValueReferenceTest(Vector3.zero, Vector3.one);
        [Test]
        public void Vector3ValueReferenceTestReversed() => ValueReferenceTest(Vector3.one, Vector3.zero);
        
        private void ValueReferenceTest<T>(T defaultValue, T newValue)
        {
            Reference<T> reference = new Reference<T>(defaultValue);

            // Test reference value
            Assert.AreEqual(reference.Value, defaultValue);

            // Test subscription from reference
            // -> subscription should be null as we cannot subscribe to a Constant
            int count = 0;
            IDisposable subscription = reference.Subscribe(_ => count++);
            Assert.IsNull(subscription);
            
            // -> callback should still have been raised
            int expectedCount = 1;
            Assert.AreEqual(count, expectedCount);

            // Test value change
            // -> callback should not been raised as we cannot subscribe to a value
            reference.Value = newValue;
            Assert.AreEqual(reference.Value, newValue);
            Assert.AreEqual(count, expectedCount);
        }
    }
}