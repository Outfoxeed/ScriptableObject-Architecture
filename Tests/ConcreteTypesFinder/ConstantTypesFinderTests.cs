using NUnit.Framework;
using ScriptableObjectArchitecture.Constants;
using ScriptableObjectArchitecture.Variables;
using UnityEngine;

namespace ScriptableObjectArchitecture.Tests.ConcreteTypesFinderTests
{
    public class ConstantTypesFinderTests : ConcreteTypesFinderTestBase
    {
        [Test]
        public void FindBoolConstant() => FindClass(typeof(Constant<bool>), "BoolConstant");
        [Test]
        public void FindStringConstant() => FindClass(typeof(Constant<string>), "StringConstant");
        [Test]
        public void FindGameObjectConstant() => FindClass(typeof(Constant<GameObject>), "GameObjectConstant");
    }
}