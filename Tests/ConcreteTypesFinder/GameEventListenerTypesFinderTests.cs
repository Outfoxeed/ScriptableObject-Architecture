using NUnit.Framework;
using ScriptableObjectArchitecture.GameEventListeners;
using UnityEngine;

namespace ScriptableObjectArchitecture.Tests.ConcreteTypesFinderTests
{
    public class GameEventListenerTypesFinderTests : ConcreteTypesFinderTestBase
    {
        [Test]
        public void FindGameEventListener() => FindClass(typeof(GameEventListener<Void>), "VoidGameEventListener");

        [Test]
        public void FindBoolGameEventListener() => FindClass(typeof(GameEventListener<bool>), "BoolGameEventListener");

        [Test]
        public void FindStringGameEventListener() => FindClass(typeof(GameEventListener<string>), "StringGameEventListener");

        [Test]
        public void FindGameObjectGameEventListener() => FindClass(typeof(GameEventListener<GameObject>), "GameObjectGameEventListener");
    }
}