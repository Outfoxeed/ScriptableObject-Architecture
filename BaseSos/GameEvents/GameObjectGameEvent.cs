using UnityEngine;

namespace ScriptableObjectArchitecture.GameEvents
{
    [CreateAssetMenu(menuName = CreateAssetMenuConstants.GameEventsPath + "GameObject")]
    internal class GameObjectGameEvent : GameEvent<GameObject>
    {
    }
}
