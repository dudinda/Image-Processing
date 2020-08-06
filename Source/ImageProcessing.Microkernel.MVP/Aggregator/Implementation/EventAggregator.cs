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
                        InvokeSubscriberEvent(args, subscriber, pair.Publisher);
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
                        InvokeSubscriberEvent(args, subscriber, publisher);
                    }
                }
            }
        }

        /// <inheritdoc cref="IEventAggregator.Subscribe(object, object)"/>
        public void Subscribe(object subscriber, object publisher)
        {
            var subscriberType = subscriber.GetType();

            var subsriberTypes = subscriberType.GetInterfaces()
                .Where(i => i.IsGenericType &&
                       i.GetGenericTypeDefinition() == typeof(ISubscriber<>));

            lock (_syncRoot)
            {
                foreach (var subsriberType in subsriberTypes)
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
            var subsriberTypes = subscriber.GetInterfaces()
                .Where(i => i.IsGenericType &&
                       i.GetGenericTypeDefinition() == typeof(ISubscriber<>));

            lock (_syncRoot)
            {
                foreach (var subsriberType in subsriberTypes)
                {
                    var subscribers = GetSubscribers(subsriberType);
                        subscribers.RemoveWhere(
                            pair => pair.Publisher == publisher
                        );
                }
            }
        }

        private void InvokeSubscriberEvent<TEventArgs>(
            TEventArgs args,
            ISubscriber<TEventArgs> subscriber,
            object publisher)
        {
            Post(s => subscriber.OnEventHandler(publisher, args), null);
        }

        private HashSet<(object Subscriber, object Publisher)> GetSubscribers(Type subsriberType)
        {
            lock (_syncRoot)
            {
                var isFound = _eventSubscribers
                    .TryGetValue(
                        subsriberType, out var subsribers
                     );

                if (!isFound)
                {
                    subsribers = new HashSet<(object, object)>();

                    _eventSubscribers.Add(subsriberType, subsribers);
                }

                return subsribers;
            }
        }

        internal virtual void Post(SendOrPostCallback d, object state)
        {
            var syncContext = SynchronizationContext.Current
                ?? new SynchronizationContext();

            syncContext.Post(d, state);
        }
    }
}
