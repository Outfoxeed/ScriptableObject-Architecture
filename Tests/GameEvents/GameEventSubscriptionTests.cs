using System;
using System.Collections;
using NUnit.Framework;
using ScriptableObjectArchitecture.GameEvents;
using UniRx;
using UnityEngine;
using UnityEngine.TestTools;

namespace ScriptableObjectArchitecture.Tests.GameEvents
{
    public class GameEventSubscriptionTests
    {
        // (Void) Game Event
        [UnityTest]
        public IEnumerator GameEventSubscription() => GameEventSubscriptionTest(Void.Default);
        
        // Bool
        [UnityTest]
        public IEnumerator BoolGameEventSubscriptionTrue() => GameEventSubscriptionTest(true);
        [UnityTest]
        public IEnumerator BoolGameEventSubscriptionFalse() => GameEventSubscriptionTest(false);
        
        // String
        [UnityTest]
        public IEnumerator StringGameEventSubscription() => GameEventSubscriptionTest("Hello World!");
        [UnityTest]
        public IEnumerator StringGameEventSubscriptionNull() => GameEventSubscriptionTest<string>(null);
        
        // GameObject 
        [UnityTest]
        public IEnumerator GameObjectGameEventSubscription() => GameEventSubscriptionTest(new GameObject());
        [UnityTest]
        public IEnumerator GameObjectGameEventSubscriptionNull() => GameEventSubscriptionTest<GameObject>(null);
        
        private IEnumerator GameEventSubscriptionTest<T>(T raiseParameter)
        {
            GameEvent<T> gameEvent =
                (GameEvent<T>)ScriptableObject.CreateInstance(ConcreteTypesFinder.GetConcreteType<GameEvent<T>>());
            Assert.IsNotNull(gameEvent);
            gameEvent.name = $"Test GameEvent ({typeof(T).Name})";

            gameEvent.Raise(raiseParameter);

            // Test subscription callback raise
            // -> callback should not be raised
            int count = 0;
            IDisposable subscription = gameEvent.Subscribe(_ => count++);
            int expectedCount = 0;
            Assert.AreEqual(count, expectedCount);
            
            // Test GameEvent raise
            // -> callback should be raised
            gameEvent.Raise(raiseParameter);
            expectedCount++;
            Assert.AreEqual(count, expectedCount);

            // Test dispose
            // -> Callback shouldn't be raised
            subscription.Dispose();
            gameEvent.Raise(raiseParameter);
            Assert.AreEqual(count, expectedCount);

            subscription = null;
            yield return null;
        }
    }
}