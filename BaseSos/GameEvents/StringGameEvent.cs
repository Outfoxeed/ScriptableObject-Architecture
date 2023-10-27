using UnityEngine;

namespace ScriptableObjectArchitecture.GameEvents
{
    [CreateAssetMenu(fileName = "New Game Event String", menuName = "GameEvents/GameEvent (string)", order = 1)]
    internal class StringGameEvent : GameEvent<string>
    {
    }
}
