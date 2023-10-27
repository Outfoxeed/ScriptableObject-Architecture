using UnityEngine;

namespace ScriptableObjectArchitecture.GameEvents
{
    [CreateAssetMenu(fileName = "New Game Event Int", menuName = "GameEvents/Game Event (int)", order = 1)]
    internal class IntGameEvent : GameEvent<int>
    {
    }
}
