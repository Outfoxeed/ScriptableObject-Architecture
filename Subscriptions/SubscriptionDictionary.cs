using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScriptableObjectArchitecture.Subscriptions
{
    public class SubscriptionDictionary<T> : Dictionary<object, List<Subscription<T>>>, ISubscriptionDictionary<T>
    {
        public bool RaiseAllSubscriptions(T parameter)
        {
            var cachedValues = Values.ToList();
            if (cachedValues.Count == 0)
            {
                return false;
            }
            
            for (int i = cachedValues.Count - 1; i >= 0; i--)
            {
                for (int j = cachedValues[i].Count - 1; j >= 0; j--)
                {
                    cachedValues[i][j].Raise(parameter);
                }
            }
            return true;
        }
        
        public IDisposable AddSubscription(object subscriber, string subscriptionName, Action<T> callback)
        {
            Subscription<T> subscription = new Subscription<T>(subscriber, subscriptionName, callback, this);
            if (ContainsKey(subscriber))
            {
                this[subscriber].Add(subscription);
                return subscription;
            }
            
            List<Subscription<T>> subscriptions = new List<Subscription<T>> {subscription};
            this.Add(subscriber, subscriptions);
            return subscription;
        }
        
        #region Remove

        public bool RemoveAllSubscriptions(object subscriber)
        {
            if (!ContainsKey(subscriber))
            {
                return false;
            }

            this[subscriber].Clear();
            this[subscriber] = null;
            return Remove(subscriber);
        }

        public bool RemoveSubscription(object subscriber, string subscriptionName)
        {
            if (!ContainsKey(subscriber))
            {
                return false;
            }

            List<Subscription<T>> foundSubscriptions = this[subscriber];
            for (int i = foundSubscriptions.Count - 1; i >= 0; i--)
            {
                if (foundSubscriptions[i].Name == subscriptionName)
                {
                    foundSubscriptions.RemoveAt(i);
                    if (foundSubscriptions.Count == 0)
                    {
                        return this.Remove(subscriber);
                    }
                    return true;
                }
            }
            return false;
        }

        public bool RemoveSubscription(string subscriptionName)
        {
            foreach (var (subscriber, subscriptions) in this)
            {
                for (int i = subscriptions.Count - 1; i >= 0; i--)
                {
                    if (subscriptions[i].Name == subscriptionName)
                    {
                        subscriptions.RemoveAt(i);
                        if (subscriptions.Count == 0)
                        {
                            return this.Remove(subscriber);
                        }
                        return true;
                    }
                }
            }
            return false;
        }
        #endregion

        public override string ToString()
        {
            StringBuilder sb = new();
            sb.Append("{ ");
            foreach (KeyValuePair<object,List<Subscription<T>>> keyValuePair in this)
            {
                sb.Append("\n  {");

                string subscriberName =
                    $"{keyValuePair.Key.ToString().Split()[0]} ({keyValuePair.Key.GetType().ToString().Split(new[] {'.', '+', '-'})[^1]})";
                sb.Append($"\n\tsubscriber: {subscriberName};");
                sb.Append("\n\tsubscriptions:");
                foreach (Subscription<T> subscription in keyValuePair.Value)
                {
                    sb.Append(string.Concat("\n\t\t",subscription.ToString()));
                }
                sb.Append("\n  }");
            }
            sb.Append("\n}");
            return sb.ToString();
        }
    }
}