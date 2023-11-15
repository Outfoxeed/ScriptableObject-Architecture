using UnityEngine;

namespace ScriptableObjectArchitecture.GameEvents
{
    [CreateAssetMenu(menuName = CreateAssetMenuConstants.GameEventsPath + "Void", order = 0)]
    public class GameEvent : GameEvent<Void>
    {
#if UNITY_EDITOR
        public override bool RaiseWithDebugParameter() => Raise();
#endif
        
        public bool Raise() => this.Raise(Void.Default);
    }
}
