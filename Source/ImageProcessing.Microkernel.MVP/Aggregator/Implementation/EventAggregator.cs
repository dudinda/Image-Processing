using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

using ImageProcessing.Microkernel.MVP.Aggregator.Interface;
using ImageProcessing.Microkernel.MVP.Aggregator.Subscriber;

namespace ImageProcessing.Microkernel.MVP.Aggregator.Implementation
{
    /// <inheritdoc cref="IEventAggregator"/>
    internal class EventAggregator : IEventAggregator
    {
        private readonly object _syncRoot = new object();

        private readonly Dictionary<Type, HashSet<(object, object)>> _eventSubscribers
            = new Dictionary<Type, HashSet<(object, object)>>();

        /// <inheritdoc cref="IEventAggregator.PublishFrom{TEventArgs}(object, TEventArgs)"
        public void PublishFrom<TEventArgs>(object publisher, TEventArgs args)
        {
            var subsriberType = typeof(ISubscriber<>).MakeGenericType(typeof(TEventArgs));

            lock (_syncRoot)
            {
                var pairs = GetSubscribers(subsriberType).Where((pair) => pair.Publisher == publisher);

                foreach (var pair in pairs)
                {
                    var subscriber = pair.Subscriber as ISubscriber<TEventArgs>;

                    if (subscriber != null)
                    {
                        Post(s => subscriber.OnEventHandler(pair.Publisher, args), null);
                    }
                }
            }
        }

        /// <inheritdoc cref="IEventAggregator.PublishFromAll{TEventArgs}(object, TEventArgs)"
        public void PublishFromAll<TEventArgs>(object publisher, TEventArgs args)
        {
            var subsriberType = typeof(ISubscriber<>).MakeGenericType(typeof(TEventArgs));

            lock (_syncRoot)
            {
                foreach (var pair in GetSubscribers(subsriberType))
                {
                    var subscriber = pair.Subscriber as ISubscriber<TEventArgs>;

                    if (subscriber != null)
                    {
                        Post(s => subscriber.OnEventHandler(publisher, args), null);
                    }
                }
            }
        }

        /// <inheritdoc cref="IEventAggregator.Subscribe(object, object)"/>
        public void Subscribe(object subscriber, object publisher)
        {
            var types = GetSubsciberTypes(subscriber.GetType());

            lock (_syncRoot)
            {
                foreach (var subsriberType in types)
                {
                    var subscribers = GetSubscribers(subsriberType);

                    if (!subscribers.Any(pair => pair.Subscriber == subscriber))
                    {
                        subscribers.Add((subscriber, publisher));
                    }             
                }
            }
        }

        /// <inheritdoc cref="IEventAggregator.Unsubscribe(Type, object))"/>
        public void Unsubscribe(Type subscriber, object publisher)
        {
            var types = GetSubsciberTypes(subscriber);

            lock (_syncRoot)
            {
                foreach (var subsriberType in types)
                {
                    var subscribers = GetSubscribers(subsriberType);
                        subscribers.RemoveWhere(
                            pair => pair.Publisher == publisher
                        );
                }
            }
        }

        internal virtual void Post(SendOrPostCallback callback, object state)
        {
            var syncContext = SynchronizationContext.Current
                ?? new SynchronizationContext();

            syncContext.Post(callback, state);
        }

        private HashSet<(object Subscriber, object Publisher)> GetSubscribers(Type subsriberType)
        {
            lock (_syncRoot)
            {
                var isFound = _eventSubscribers.TryGetValue(
                        subsriberType, out var subscribers);

                if (!isFound)
                {
                    subscribers = new HashSet<(object, object)>();

                    _eventSubscribers.Add(subsriberType, subscribers);
                }

                return subscribers;
            }
        }

        private IEnumerable<Type> GetSubsciberTypes(Type subscriberType)
            => subscriberType.GetInterfaces().Where(
                i => i.IsGenericType &&
                i.GetGenericTypeDefinition() == typeof(ISubscriber<>)
            );    
    }
}
