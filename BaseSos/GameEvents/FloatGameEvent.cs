using UnityEngine;

namespace ScriptableObjectArchitecture.GameEvents
{
    [CreateAssetMenu(fileName = "New Game Event Float", menuName = "GameEvents/Game Event (float)", order = 1)]
    internal class FloatGameEvent : GameEvent<float>
    {
    }
}
