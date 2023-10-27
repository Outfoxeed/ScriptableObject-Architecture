using UnityEngine;

namespace ScriptableObjectArchitecture.GameEvents
{
    [CreateAssetMenu(fileName = "New Game Event Bool", menuName = "GameEvents/GameEvent (bool)", order = 1)]
    internal class BoolGameEvent : GameEvent<bool>
    {
    }
}
