using NUnit.Framework;
using ScriptableObjectArchitecture.GameEvents;
using UnityEngine;

namespace ScriptableObjectArchitecture.Tests.ConcreteTypesFinderTests
{
    public class GameEventTypesFinderTests : ConcreteTypesFinderTestBase
    {
        [Test]
        public void FindGameEvent() => FindClass(typeof(GameEvent<Void>), "VoidGameEvent");
        [Test]
        public void FindBoolGameEvent() => FindClass(typeof(GameEvent<bool>), "BoolGameEvent");
        [Test]
        public void FindStringGameEvent() => FindClass(typeof(GameEvent<string>), "StringGameEvent");
        [Test]
        public void FindGameObjectGameEvent() => FindClass(typeof(GameEvent<GameObject>), "GameObjectGameEvent");
    }
}