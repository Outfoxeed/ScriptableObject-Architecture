using System;
using ScriptableObjectArchitecture.Subscriptions;
#if UNITY_EDITOR || DEVELOPMENT_BUILD
using UnityEngine;
#endif

namespace ScriptableObjectArchitecture.GameEvents
{
    public abstract class GameEvent<T> : ReadOnlyGameEvent<T>, IGameEvent<T>
    {
#if UNITY_EDITOR
        [SerializeField] private bool _debugMode;
        [SerializeField, Multiline] private string _description;
#endif
        
        protected ISubscriptionDictionary<T> SubscriptionDictionary
        {
            get
            {
                if (_subscriptionDictionary == null)
                {
                    _subscriptionDictionary = new SubscriptionDictionary<T>();
                }
                return _subscriptionDictionary;
            }
        }
        private SubscriptionDictionary<T> _subscriptionDictionary;
        
        public override IDisposable Subscribe(object subscriber, string subscriptionName, Action<T> callback)
        {
            IDisposable subscriptionDisposable = SubscriptionDictionary.AddSubscription(subscriber, subscriptionName, callback);
            DevelopmentLog($"'{this.name}' received a new subscription from '{subscriber}' (subscription name: {subscriptionName})\n{this}");
            return subscriptionDisposable;
        }
        public override IDisposable Subscribe(object subscriber, string subscriptionName, Action callback)
        {
            return Subscribe(subscriber, subscriptionName, _ => callback?.Invoke());
        }

        public bool Raise(object sender, T parameter)
        {
#if UNITY_EDITOR || DEVELOPMENT_BUILD
            Debug.Log($"'{this.name}' GameEvent raised with parameter '{parameter.ToString()}'  (raiser: {sender})");
#endif
            return SubscriptionDictionary.RaiseAllSubscriptions(parameter);
        }
        public bool Raise(object sender)
        {
            return Raise(sender, parameter: default);
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
