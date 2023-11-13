using System;
using System.Collections;
using NUnit.Framework;
using ScriptableObjectArchitecture.RuntimeSets;
using UniRx;
using UnityEngine;
using UnityEngine.TestTools;

namespace ScriptableObjectArchitecture.Tests.RuntimeSets
{
    public class RuntimeSetObservableTests
    {
        // Bool
        [UnityTest]
        public IEnumerator BoolRuntimeSetObserveCount() => RuntimeSetObserveCountTest(true);
        [UnityTest]
        public IEnumerator BoolRuntimeSetObserveCountAlternate() => RuntimeSetObserveCountTest(false);

        // String
        [UnityTest]
        public IEnumerator StringRuntimeSetObserveCount() => RuntimeSetObserveCountTest("Hello World!");
        [UnityTest]
        public IEnumerator StringRuntimeSetObserveCountNull() => RuntimeSetObserveCountTest<string>(null);
        [UnityTest]
        public IEnumerator StringRuntimeSetObserveCountEmpty() => RuntimeSetObserveCountTest<string>("");
        
        // GameObject
        [UnityTest]
        public IEnumerator GameObjectRuntimeSetObserveCount() => RuntimeSetObserveCountTest(new GameObject());
        [UnityTest]
        public IEnumerator GameObjectRuntimeSetObserveCountNull() => RuntimeSetObserveCountTest<GameObject>(null);
        
        // Vector3
        [UnityTest]
        public IEnumerator Vector3RuntimeSetObserveCount() => RuntimeSetObserveCountTest(Vector3.zero);
        [UnityTest]
        public IEnumerator Vector3RuntimeSetObserveCountAlternate() => RuntimeSetObserveCountTest(Vector3.one);

        private IEnumerator RuntimeSetObserveCountTest<T>(T validValue)
        {
            RuntimeSet<T> runtimeSet =
                (RuntimeSet<T>)ScriptableObject.CreateInstance(ConcreteTypesFinder.GetConcreteType<RuntimeSet<T>>());
            Assert.IsNotNull(runtimeSet);

            int addCount = 0;
            int expectedAddCount = 0;
            IDisposable addSubscription = runtimeSet.ObserveAdd().Subscribe(_ => addCount++);
            
            int removeCount = 0;
            int expectedRemoveCount = 0;
            IDisposable removeSubscription = runtimeSet.ObserveRemove().Subscribe(_ => removeCount++);
            
            int countChangedCount = 0;
            int expectedCountChangedCount = 0;
            IDisposable countChangedSubscription = runtimeSet.ObserveCountChanged().Subscribe(_ => countChangedCount++);

            int clearCount = 0;
            int expectedClearCount = 0;
            IDisposable clearSubscription = runtimeSet.ObserveClear().Subscribe(_ => clearCount++);

            for (int i = 0; i < 2; i++)
            {
                runtimeSet.Add(validValue);
                expectedAddCount++;
                expectedCountChangedCount++;
                Assert.AreEqual(addCount, expectedAddCount);
                Assert.AreEqual(countChangedCount, expectedCountChangedCount);
            }

            for (int i = 0; i < 1; i++)
            {
                runtimeSet.RemoveAt(0);
                expectedRemoveCount++;
                expectedCountChangedCount++;
                Assert.AreEqual(removeCount, expectedRemoveCount);
                Assert.AreEqual(countChangedCount, expectedCountChangedCount);
            }
            
            runtimeSet.Clear();
            expectedClearCount++;
            expectedCountChangedCount++;
            Assert.AreEqual(clearCount, expectedClearCount);
            Assert.AreEqual(countChangedCount, expectedCountChangedCount);
            Assert.AreEqual(runtimeSet.Count, 0);

            yield return null;
        }
    }
}