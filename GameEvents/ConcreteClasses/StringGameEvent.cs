using UnityEngine;

namespace ScriptableObjectArchitecture.GameEvents.ConcreteClasses
{
    [CreateAssetMenu(fileName = "New Game Event String", menuName = "GameEvents/GameEvent (string)", order = 1)]
    internal class StringGameEvent : GameEvent<string>
    {
    }
}
