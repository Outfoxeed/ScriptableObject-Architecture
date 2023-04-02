using System.Reflection;
using ScriptableObjectArchitecture.GameEvents.ConcreteClasses;
using UnityEditor;

namespace ScriptableObjectArchitecture.GameEvents.Editor
{
    [CustomEditor(typeof(GameEvent), true)]
    public class GameEventInspector : GameEventInspectorBase
    {
        private const string _subscriptionsDictionaryName = "_subscriptionDictionary";

        protected override FieldInfo GetSubscriptionDictionaryFieldInfo()
        {
            return target.GetType().GetField(_subscriptionsDictionaryName,
                BindingFlags.Instance | BindingFlags.NonPublic);
        }
    }
}