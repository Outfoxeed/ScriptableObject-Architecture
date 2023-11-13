using System.Collections;
using System.Linq;
using NUnit.Framework;
using ScriptableObjectArchitecture.RuntimeSets;
using UnityEngine;
using UnityEngine.TestTools;

namespace ScriptableObjectArchitecture.Tests.RuntimeSets
{
    public class RuntimeSetAddTests
    {
        // Bool
        [UnityTest]
        public IEnumerator BoolRuntimeSetAdd() => RuntimeSetAddTest(new[] { false, true, false, true, false });
        [UnityTest]
        public IEnumerator BoolRuntimeSetAddAlternative() => RuntimeSetAddTest(new[] { true, true, true, true, true });

        // String
        [UnityTest]
        public IEnumerator StringRuntimeSetAdd() => RuntimeSetAddTest(new[] { "H", "e", "l", "l", "o", " ", "World!" });
        
        // GameObject
        [UnityTest]
        public IEnumerator GameObjectRuntimeSetAdd() => RuntimeSetAddTest(new[]{ new GameObject(), new GameObject(), new GameObject()});
        [UnityTest]
        public IEnumerator GameObjectRuntimeSetAddAlternative() => RuntimeSetAddTest(new[]{ new GameObject()});
        
        // Vector3
        [UnityTest]
        public IEnumerator Vector3RuntimeSetAdd() => RuntimeSetAddTest(new[] { Vector3.zero, Vector3.one, Vector3.zero, Vector3.up });

        private IEnumerator RuntimeSetAddTest<T>(T[] values)
        {
            RuntimeSet<T> runtimeSet =
                (RuntimeSet<T>)ScriptableObject.CreateInstance(ConcreteTypesFinder.GetConcreteType<RuntimeSet<T>>());
            Assert.IsNotNull(runtimeSet);
            runtimeSet.name = $"Test RuntimeSet ({typeof(T)})";

            for (int i = 0; i < values.Length; i++)
            {
                runtimeSet.Add(values[i]);
            }
            
            // Test count equality
            Assert.AreEqual(runtimeSet.Count, values.Length);
            
            // Test array equality
            Assert.AreEqual(runtimeSet.ToArray(), values);
            
            // Test value equality in for loop
            for (int i = 0; i < runtimeSet.Count; i++)
            {
                Assert.AreEqual(runtimeSet[i], values[i]);
            }
            
            // Test value equality if foreach loop
            int index = 0;
            foreach (T runtimeSetElement in runtimeSet)
            {
                Assert.AreEqual(runtimeSetElement, values[index]);
                index++;
            }

            yield return null;
        }
    }
}