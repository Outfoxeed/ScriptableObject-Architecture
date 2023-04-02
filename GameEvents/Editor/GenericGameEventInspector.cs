using System.Reflection;
using UnityEditor;

namespace ScriptableObjectArchitecture.GameEvents.Editor
{
    [CustomEditor(typeof(GameEvent<>), true)]
    public class GenericGameEventInspector : GameEventInspectorBase
    {
        private const string _subscriptionsDictionaryName = "_subscriptionDictionary";
        protected override FieldInfo GetSubscriptionDictionaryFieldInfo()
        {
            return target.GetType().BaseType.GetField(_subscriptionsDictionaryName,
                BindingFlags.Instance | BindingFlags.NonPublic);
        }
    }
}