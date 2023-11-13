using System;
using NUnit.Framework;

namespace ScriptableObjectArchitecture.Tests.ConcreteTypesFinderTests
{
    public abstract class ConcreteTypesFinderTestBase
    {
        protected void FindClass(Type abstractType, string concreteClassName)
        {
            Type result = ConcreteTypesFinder.GetConcreteType(abstractType);
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Name, concreteClassName);
        }
    }
}