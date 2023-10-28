using UnityEngine;

namespace ScriptableObjectArchitecture.GameEvents
{
    [CreateAssetMenu(menuName = CreateAssetMenuConstants.GameEventsPath + "Double")]
    internal class DoubleGameEvent : GameEvent<double>
    {
    }
}
