using System;
using ScriptableObjectArchitecture.Subscriptions;
using UnityEngine;

namespace ScriptableObjectArchitecture.GameEvents.ConcreteClasses
{
    [CreateAssetMenu(fileName = "New Game Event Simple", menuName = "GameEvents/Game Event", order = 0)]
    public class GameEvent : ReadOnlyGameEvent, IGameEvent
    {
#if UNITY_EDITOR
        [SerializeField] private bool _debugMode;
        [SerializeField, Multiline] private string _description;
#endif

        protected ISubscriptionDictionary<Empty> SubscriptionDictionary 
        {
            get
            {
                if (_subscriptionDictionary is null)
                {
                    _subscriptionDictionary = new SubscriptionDictionary<Empty>();
                }
        
                return _subscriptionDictionary;
            }
        }
        private SubscriptionDictionary<Empty> _subscriptionDictionary;

        public override IDisposable Subscribe(object subscriber, string subscriptionName, Action<Empty> callback)
        {
            IDisposable subscriptionDisposable = SubscriptionDictionary.AddSubscription(subscriber, subscriptionName, callback);
            DevelopmentLog($"'{this.name}' received a new subscription from '{subscriber}' (subscription name: {subscriptionName})\n{this}");
            return subscriptionDisposable;
        }
        public override IDisposable Subscribe(object subscriber, string subscriptionName, Action callback)
        {
            return Subscribe(subscriber, subscriptionName, _ => callback?.Invoke());
        }

        public bool Raise(object sender)
        {
#if UNITY_EDITOR || DEVELOPMENT_BUILD
            Debug.Log($"'{this.name}' GameEvent raised. (raiser: {sender})");
#endif
            return SubscriptionDictionary.RaiseAllSubscriptions(default);
        }
        
        private void DevelopmentLog(string message)
        {
#if UNITY_EDITOR
            if(_debugMode)
            {
#if UNITY_EDITOR || DEVELOPMENT_BUILD
                Debug.Log(message);
#endif            
            }
#endif
        }

        public override string ToString()
        {
            return $"'{this.name}' game event: {{subscriptions: {_subscriptionDictionary}}}";
        }
    }
}
