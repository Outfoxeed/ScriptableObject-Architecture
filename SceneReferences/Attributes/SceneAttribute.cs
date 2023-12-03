using System;
using UnityEngine;

namespace ScriptableObjectArchitecture.SceneReferences
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class SceneAttribute : PropertyAttribute
    {
    }
}