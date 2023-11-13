using NUnit.Framework;
using ScriptableObjectArchitecture.Variables;
using UnityEngine;

namespace ScriptableObjectArchitecture.Tests.ConcreteTypesFinderTests
{
    public class VariableTypesFinderTests : ConcreteTypesFinderTestBase
    {
        [Test]
        public void FindBoolVariable() => FindClass(typeof(Variable<bool>), "BoolVariable");
        [Test]
        public void FindStringVariable() => FindClass(typeof(Variable<string>), "StringVariable");
        [Test]
        public void FindGameObjectVariable() => FindClass(typeof(Variable<GameObject>), "GameObjectVariable");
    }
}