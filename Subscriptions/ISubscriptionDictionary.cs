using System;

namespace ScriptableObjectArchitecture.Subscriptions
{
    public interface ISubscriptionDictionary<T>
    {
        public bool RaiseAllSubscriptions(T parameter);
        
        public IDisposable AddSubscription(object subscriber, string subscriptionName, Action<T> callback);
        
        public bool RemoveAllSubscriptions(object subscriber);
        public bool RemoveSubscription(object subscriber, string subscriptionName);
        public bool RemoveSubscription(string subscriptionName);
    }
}