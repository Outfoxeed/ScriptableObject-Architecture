using System;
using System.Collections.Generic;
using System.Reflection;

namespace ScriptableObjectArchitecture
{
    /// <summary>
    /// Static class able to find the concrete type from a base Type 
    /// </summary>
    public static class ConcreteTypesFinder
    {
        private static Dictionary<System.Type, System.Type> _concreteTypes = new();
        
        public static System.Type GetConcreteType<TU>() => GetConcreteType(typeof(TU));
        public static Type GetConcreteType(Type baseType)
        {
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
