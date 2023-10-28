using UnityEngine;

namespace ScriptableObjectArchitecture.GameEvents
{
    [CreateAssetMenu(menuName = CreateAssetMenuConstants.GameEventsPath + "Float")]
    internal class FloatGameEvent : GameEvent<float>
    {
    }
}
