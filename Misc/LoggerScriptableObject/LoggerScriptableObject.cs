using ScriptableObjectArchitecture.Variables;
using UnityEngine;

namespace ScriptableObjectArchitecture.Misc.LoggerScriptableObject
{
    [CreateAssetMenu(menuName = "SO Arch/Misc/Logger")]
    public class LoggerScriptableObject : ScriptableObject
    {
        private const string LogPrefix = "[LOGGER SO]";
    
        public void Log(string value) => Log<string>(value);
        public void Log(int value) => Log<int>(value);
        public void Log(float value) => Log<float>(value);
        public void Log(double value) => Log<double>(value);
        public void Log(bool value) => Log<bool>(value);
        public void Log(Vector2 value) => Log<Vector2>(value);
        public void Log(Color value) => Log<Color>(value);
        

        public void Log(GameObject gameObject) => Log($"GameObject: {ToString(gameObject)}");
        public void Log(Transform transform) => Log($"Transform: {ToString(transform)}");
        public void Log(Behaviour behaviour) => Log($"Behaviour: {ToString(behaviour)}");
        public void Log(MonoBehaviour monoBehaviour) => Log($"MonoBehaviour: {ToString(monoBehaviour)}");
        public void Log(Component component) => Log($"Component: {ToString(component)}");

    
        private void Log<T>(T value) => Debug.Log($"{LogPrefix} {value}");
        private string ToString(GameObject gameObject) => $"{{name: {gameObject.name}, id: {gameObject.GetInstanceID()}}}";
        private string ToString(Transform transform) => $"{{position: {transform.position}, gameObject: {ToString(transform.gameObject)}}}";
        private string ToString(Behaviour behaviour) => $"{GetTypeDisplayName(behaviour.GetType())}: {{enabled, {behaviour.enabled}, gameObject: {ToString(behaviour.gameObject)}}}";
        private string ToString(Component component) => $"{GetTypeDisplayName(component.GetType())}: {{gameObject: {ToString(component.gameObject)}}}";

    
        private string GetTypeDisplayName(System.Type type) => type.ToString().Split(new[] {'.', '+'})[^1];
    }
}
