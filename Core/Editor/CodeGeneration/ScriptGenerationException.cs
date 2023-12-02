using System;

namespace ScriptableObjectArchitecture.Editor.CodeGeneration
{
    public class ScriptGenerationException : Exception
    {
        public ScriptGenerationException(string message) : base(message)
        {
        }
    }
}