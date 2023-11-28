using System.Collections;
using NUnit.Framework;
using ScriptableObjectArchitecture.Instancers;
using ScriptableObjectArchitecture.Variables;
using UnityEngine;
using UnityEngine.TestTools;

namespace ScriptableObjectArchitecture.Tests
{
    public class ScriptableObjectInstancerTests
    {
        private IEnumerator CheckSoValidity<T>() where T : ScriptableObject
        {
            var go = new GameObject();
            ScriptableObjectInstancer<T> soInstancer =
                (ScriptableObjectInstancer<T>)go.AddComponent(ConcreteTypesFinder.GetConcreteType<ScriptableObjectInstancer<T>>());
        
            Assert.IsNotNull(soInstancer);
            Assert.IsNotNull(soInstancer.So);

            yield return null;
        }
        
        [UnityTest]
        public IEnumerator BoolVariableInstantiation()
        {
            yield return CheckSoValidity<Variable<bool>>();
        }
        
        [UnityTest]
        public IEnumerator StringVariableInstantiation()
        {
            yield return CheckSoValidity<Variable<string>>();
        }
        
        [UnityTest]
        public IEnumerator GameObjectVariableInstantiation()
        {
            yield return CheckSoValidity<Variable<GameObject>>();
        }
    }
}