using UnityEngine;

namespace ScriptableObjectArchitecture.GameEvents
{
    [CreateAssetMenu(menuName = CreateAssetMenuConstants.GameEventsPath + "Int")]
    internal class IntGameEvent : GameEvent<int>
    {
    }
}
