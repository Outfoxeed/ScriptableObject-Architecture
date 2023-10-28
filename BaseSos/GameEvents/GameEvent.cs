using ScriptableObjectArchitecture.Utils;
using UnityEngine;

namespace ScriptableObjectArchitecture.GameEvents
{
    [CreateAssetMenu(menuName = CreateAssetMenuConstants.GameEventsPath + "Void", order = 0)]
    public class GameEvent : GameEvent<Void>
    {
    }
}
