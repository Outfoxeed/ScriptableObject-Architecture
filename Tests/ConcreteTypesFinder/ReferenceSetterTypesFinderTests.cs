using NUnit.Framework;
using ScriptableObjectArchitecture.ReferenceSetters;
using UnityEngine;

namespace ScriptableObjectArchitecture.Tests.ConcreteTypesFinderTests
{
    public class ReferenceSetterTypesFinderTests : ConcreteTypesFinderTestBase
    {
        [Test]
        public void FindGameObjectReferenceSetter() => FindClass(typeof(ReferenceSetter<GameObject>), "GameObjectReferenceSetter");
        [Test]
        public void FindBoolReferenceSetter() => FindClass(typeof(ReferenceSetter<bool>), "BoolReferenceSetter");
        [Test]
        public void FindStringReferenceSetter() => FindClass(typeof(ReferenceSetter<string>), "StringReferenceSetter");
    }
}