using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace ScriptableObjectArchitecture.Instancers
{
    /// <summary>
    /// MonoBehaviour class instantiating a ScriptableObject at Awake
    /// </summary>
    /// <typeparam name="T">Type of the ScriptableObject to instantiate</typeparam>
    [DefaultExecutionOrder(-100)]
    public abstract class ScriptableObjectInstancer<T> : MonoBehaviour, IGetSo<T> where T : ScriptableObject
    {
        public T So { get; private set; }
        ScriptableObject IGetSo.So => So;

        private static Dictionary<System.Type, System.Type> _concreteTypes = new();
        
        private void Awake()
        {
            So = (T)ScriptableObject.CreateInstance(GetConcreteType<T>());
        }

        private System.Type GetConcreteType<TU>() where TU : ScriptableObject
        {
            System.Type baseType = typeof(TU);

            // Return given type if already concrete
            if (!baseType.IsGenericType)
            {
                return baseType;
            }

            // Try returning already found value in dictionary
            if (_concreteTypes.TryGetValue(baseType, out var concreteType))
            {
                return concreteType;
            }
            
            // Search for concrete type in all assemblies and add it to the dictionary
            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                foreach (Type type in assembly.GetTypes())
                {
                    if (type.IsInterface || type.IsConstructedGenericType)
                    {
                        continue;
                    }
                    
                    if (!baseType.IsAssignableFrom(type))
                    {
                        continue;
                    }

                    _concreteTypes.Add(baseType, type);
                    return type;
                }
            }

            return null;
        }
    }
}