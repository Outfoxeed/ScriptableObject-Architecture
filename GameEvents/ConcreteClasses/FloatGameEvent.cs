using UnityEngine;

namespace ScriptableObjectArchitecture.GameEvents.ConcreteClasses
{
    [CreateAssetMenu(fileName = "New Game Event Float", menuName = "GameEvents/Game Event (float)", order = 1)]
    internal class FloatGameEvent : GameEvent<float>
    {
    }
}
