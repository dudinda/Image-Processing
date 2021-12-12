using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

using ImageProcessing.Microkernel.MVP.Aggregator.Interface;
using ImageProcessing.Microkernel.MVP.Aggregator.Subscriber;

namespace ImageProcessing.Microkernel.MVP.Aggregator.Implementation
{
    /// <inheritdoc cref="IEventAggregator"/>
    public class EventAggregator : IEventAggregator
    {
          private readonly object _sync = new object();

        /// <summary>
        /// Partition a presenter with a subscriber interface cast and
        /// then queue it as a callback on the syncronization context.
        /// </summary>
        private readonly Dictionary<Type, Dictionary<object, HashSet<object>>> _map
            = new Dictionary<Type, Dictionary<object, HashSet<object>>>();

        /// <inheritdoc cref="IEventAggregator.PublishFrom{TEventArgs}(object, TEventArgs)"/>
        public void PublishFrom<TEventArgs>(object publisher, TEventArgs args)
        {
            var subscriberType = typeof(ISubscriber<>).MakeGenericType(typeof(TEventArgs));

            lock (_sync)
            {
                if (GetSubscribers(subscriberType).TryGetValue(publisher, out var subs))
                {
                    foreach (var sub in subs)
                    {
                        var subscriber = sub as ISubscriber<TEventArgs>;

                        if (subscriber != null)
                        {
                            Post(s => subscriber.OnEventHandler(publisher, args), null!);
                        }
                    }
                }
            }
        }

        /// <inheritdoc cref="IEventAggregator.PublishFromAll{TEventArgs}(object, TEventArgs)"/>
        public void PublishFromAll<TEventArgs>(object publisher, TEventArgs args)
        {
            var subscriberType = typeof(ISubscriber<>).MakeGenericType(typeof(TEventArgs));

            lock (_sync)
            {
                foreach (var sub in GetSubscribers(subscriberType).Values.SelectMany(_ => _))
                {
                    var subscriber = sub as ISubscriber<TEventArgs>;
                  
                    if (subscriber != null)
                    {
                        Post(s => subscriber.OnEventHandler(publisher, args), null!);
                    }
                }
            }
        }

        /// <inheritdoc cref="IEventAggregator.Subscribe(object, object)"/>
        public void Subscribe(object subscriber, object publisher)
        {
            if (subscriber is null) { throw new ArgumentNullException(nameof(subscriber)); }
            if (publisher is null) { throw new ArgumentNullException(nameof(publisher)); }

            var types = GetSubsciberTypes(subscriber.GetType());

            lock (_sync)
            {
                Dictionary<object, HashSet<object>> pubsToSubs;

                foreach (var subscriberType in types)
                {
                    pubsToSubs = GetSubscribers(subscriberType);

                    if(!pubsToSubs.TryGetValue(publisher, out var subs))
                    {
                        subs = new HashSet<object>();
                        pubsToSubs.Add(publisher, subs);
                    }

                    if (!subs.Contains(subscriber))
                    {
                        subs.Add(subscriber);
                    }
                }
            }
        }

        /// <inheritdoc cref="IEventAggregator.Unsubscribe(Type, object)"/>
        public void Unsubscribe(Type subscriber, object publisher)
        {
            if (subscriber is null) { throw new ArgumentNullException(nameof(subscriber)); }
            if (publisher is null) { throw new ArgumentNullException(nameof(publisher)); }

            var types = GetSubsciberTypes(subscriber);

            lock (_sync)
            {
                Dictionary<object, HashSet<object>> pubsToSubs;

                foreach (var subscriberType in types)
                {
                    pubsToSubs = GetSubscribers(subscriberType);
                    pubsToSubs.Remove(publisher);

                    if(pubsToSubs.Count == 0)
                    {
                        _map.Remove(subscriberType);
                    }
                }
            }
        }

        /// <summary>
        /// To override inside the integration
        /// to run tests synchronously. 
        /// </summary>
        protected virtual void Post(SendOrPostCallback callback, object state)
        {
            var syncContext = SynchronizationContext.Current
                ?? new SynchronizationContext();

            syncContext.Post(callback, state);
        }

        private Dictionary<object, HashSet<object>> GetSubscribers(Type subsriberType)
        {
            lock (_sync)
            {
                if (!_map.TryGetValue(subsriberType, out var pubsToSubs))
                {
                    pubsToSubs = new Dictionary<object, HashSet<object>>();

                    _map.Add(subsriberType, pubsToSubs);
                }

                return pubsToSubs;
            }
        }

        private IEnumerable<Type> GetSubsciberTypes(Type subscriberType)
            => subscriberType.GetInterfaces().Where(
                i => i.IsGenericType &&
                i.GetGenericTypeDefinition() == typeof(ISubscriber<>));
    }
}
