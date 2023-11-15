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
    public class ConstantReferenceTests
    {
        // Bool
        [Test]
        public void BoolConstantReferenceTest() => ConstantReferenceTest(false);
        [Test]
        public void BoolConstantReferenceTestReversed() => ConstantReferenceTest(true);

        // String
        [Test]
        public void StringConstantReferenceTest() => ConstantReferenceTest("Hello World!");
        [Test]
        public void StringConstantReferenceTestNull() => ConstantReferenceTest<string>(null);
        
        // GameObject
        [Test]
        public void GameObjectConstantReferenceTestReversed() => ConstantReferenceTest(new GameObject());
        [Test]
        public void GameObjectConstantReferenceTestNull() => ConstantReferenceTest<GameObject>(null);
        
        // Vector3
        [Test]
        public void Vector3ConstantReferenceTest() => ConstantReferenceTest(Vector3.zero);
        [Test]
        public void Vector3ConstantReferenceTestReversed() => ConstantReferenceTest(Vector3.one);
        
        private void ConstantReferenceTest<T>(T constantValue)
        {
            Constant<T> constant = (Constant<T>)ScriptableObject.CreateInstance(ConcreteTypesFinder.GetConcreteType<Constant<T>>());
            Assert.IsNotNull(constant);
            constant.name = $"Test Constant ({typeof(T)})";

            // Set a value inside the constant
            FieldInfo valueFieldInfo = typeof(Constant<T>).GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .First(x => x.Name == "<Value>k__BackingField");
            Assert.IsNotNull(valueFieldInfo, "Value field not found in the Constant SO");
            valueFieldInfo.SetValue(constant, constantValue);

            Reference<T> reference = new Reference<T>(constant);

            // Test reference link with Constant
            Assert.AreEqual(reference.Value, constantValue);
            Assert.AreEqual(constant.Value, reference.Value);

            // Test subscription from reference
            // -> subscription should be null as we cannot subscribe to a Constant
            int count = 0;
            IDisposable subscription = reference.Subscribe(_ => count++);
            Assert.IsNull(subscription);
            
            // -> callback should still have been raised
            int expectedCount = 1;
            Assert.AreEqual(count, expectedCount);

            // Test reference set methods
            Assert.Throws<Exception>(() => reference.Value = constantValue);
            Assert.Throws<Exception>(() => reference.SetValueAndForceNotify(constantValue));
        }
    }
}