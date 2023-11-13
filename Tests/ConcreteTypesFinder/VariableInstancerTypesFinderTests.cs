using NUnit.Framework;
using ScriptableObjectArchitecture.Instancers;
using UnityEngine;

namespace ScriptableObjectArchitecture.Tests.ConcreteTypesFinderTests
{
    public class VariableInstancerTypesFinderTests : ConcreteTypesFinderTestBase
    {
        [Test]
        public void FindBoolVariableInstancer() => FindClass(typeof(VariableInstancer<bool>), "BoolVariableInstancer");
        [Test]
        public void StringVariableInstancer() => FindClass(typeof(VariableInstancer<string>), "StringVariableInstancer");
        [Test]
        public void GameObjectVariableInstancer() => FindClass(typeof(VariableInstancer<GameObject>), "GameObjectVariableInstancer");
    }
}