using NUnit.Framework;
using ScriptableObjectArchitecture.ReferenceListeners;
using UnityEngine;

namespace ScriptableObjectArchitecture.Tests.ConcreteTypesFinderTests
{
    public class ReferenceListenerTypesFinderTests : ConcreteTypesFinderTestBase
    {
        [Test]
        public void FindGameObjectReferenceListener() => FindClass(typeof(ReferenceListener<GameObject>), "GameObjectReferenceListener");
        [Test]
        public void FindBoolReferenceListener() => FindClass(typeof(ReferenceListener<bool>), "BoolReferenceListener");
        [Test]
        public void FindStringReferenceListener() => FindClass(typeof(ReferenceListener<string>), "StringReferenceListener");
    }
}