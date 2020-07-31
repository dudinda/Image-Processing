using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

using ImageProcessing.Microkernel.MVP.Aggregator.Interface;
using ImageProcessing.Microkernel.MVP.Aggregator.Subscriber;

namespace ImageProcessing.Microkernel.MVP.Aggregator.Implementation
{
    /// <inheritdoc cref="IEventAggregator"/>
    internal sealed class EventAggregator : IEventAggregator
    {
        private readonly object _syncRoot = new object();

        private Dictionary<Type, HashSet<(object, object)>> eventSubsribers
            = new Dictionary<Type, HashSet<(object, object)>>();

        /// <inheritdoc cref="IEventAggregator.Publish{TEventType}(TEventType)"/>
        public void Publish<TEventType>(TEventType publisher)
        {
            var subsriberType = typeof(ISubscriber<>).MakeGenericType(typeof(TEventType));

            var subscribers = GetSubscribers(subsriberType);
            
            var subsribersToBeRemoved = new List<WeakReference>();

            foreach (var pair in subscribers)
            {
                InvokeSubscriberEvent(
                        publisher,
                        (ISubscriber<TEventType>)pair.Subscriber
                    );
            }
        }

        /// <inheritdoc cref="IEventAggregator.Subscribe(object, object)"/>
        public void Subscribe(object subscriber, object publisher)
        {
            lock (_syncRoot)
            {

                var subscriberType = subscriber.GetType();

                var subsriberTypes = subscriberType.GetInterfaces()
                    .Where(i => i.IsGenericType &&
                           i.GetGenericTypeDefinition() == typeof(ISubscriber<>));

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

        /// <inheritdoc cref="IEventAggregator.Unsubscribe(Type, publisher))"/>
        public void Unsubscribe(Type subscriber, object publisher)
        {
            lock (_syncRoot)
            {
                var subsriberTypes = subscriber.GetInterfaces()
                    .Where(i => i.IsGenericType &&
                           i.GetGenericTypeDefinition() == typeof(ISubscriber<>));

                foreach (var subsriberType in subsriberTypes)
                {
                    var subscribers = GetSubscribers(subsriberType);
                        subscribers.RemoveWhere(
                            pair => pair.Publisher  == publisher
                        );
                }
            }
        }

        private void InvokeSubscriberEvent<TEventType>(
            TEventType publisher,
            ISubscriber<TEventType> subscriber)
        {
            var syncContext = SynchronizationContext.Current;

            if (syncContext is null)
            {
                syncContext = new SynchronizationContext();
            }

            syncContext.Post(s => subscriber.OnEventHandler(publisher), null);
        }

        private HashSet<(object Subscriber, object Publisher)> GetSubscribers(Type subsriberType)
        {
            lock (_syncRoot)
            {
                var isFound = eventSubsribers
                    .TryGetValue(
                        subsriberType, out var subsribers
                     );

                if (!isFound)
                {
                    subsribers = new HashSet<(object, object)>();

                    eventSubsribers.Add(subsriberType, subsribers);
                }

                return subsribers;
            }
        }
    }
}
