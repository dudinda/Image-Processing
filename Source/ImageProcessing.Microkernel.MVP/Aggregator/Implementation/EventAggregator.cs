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

        private Dictionary<Type, HashSet<object>> eventSubsribers
            = new Dictionary<Type, HashSet<object>>();

        /// <inheritdoc cref="IEventAggregator.Publish{TEventType}(TEventType)"/>
        public void Publish<TEventType>(TEventType publisher)
        {
            var subsriberType = typeof(ISubscriber<>).MakeGenericType(typeof(TEventType));

            var subscribers = GetSubscribers(subsriberType);
            
            var subsribersToBeRemoved = new List<WeakReference>();

            foreach (var subscriber in subscribers)
            {
                InvokeSubscriberEvent(
                        publisher,
                        (ISubscriber<TEventType>)subscriber
                    );
            }
        }

        /// <inheritdoc cref="IEventAggregator.Subscribe(object)"/>
        public void Subscribe(object subscriber)
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
                        subscribers.Add(subscriber);
                    
                }
            }
        }

        /// <inheritdoc cref="IEventAggregator.Unsubscribe(Type))"/>
        public void Unsubscribe(Type subscriber)
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
                            sub => sub.GetType() == subscriber
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

        private HashSet<object> GetSubscribers(Type subsriberType)
        {
            lock (_syncRoot)
            {
                var isFound = eventSubsribers
                    .TryGetValue(
                        subsriberType, out var subsribers
                     );

                if (!isFound)
                {
                    subsribers = new HashSet<object>();

                    eventSubsribers.Add(subsriberType, subsribers);
                }

                return subsribers;
            }
        }
    }
}
