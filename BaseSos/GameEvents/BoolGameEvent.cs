using UnityEngine;

namespace ScriptableObjectArchitecture.GameEvents
{
    [CreateAssetMenu(menuName = CreateAssetMenuConstants.GameEventsPath + "Bool")]
    internal class BoolGameEvent : GameEvent<bool>
    {
    }
}
