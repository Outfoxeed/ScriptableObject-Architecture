using UnityEngine;

namespace ScriptableObjectArchitecture.GameEvents
{
    [CreateAssetMenu(menuName = CreateAssetMenuConstants.GameEventsPath + "String")]
    internal class StringGameEvent : GameEvent<string>
    {
    }
}
