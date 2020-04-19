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

        private Dictionary<Type, List<WeakReference>> eventSubsribers
            = new Dictionary<Type, List<WeakReference>>();

        /// <inheritdoc cref="IEventAggregator.Publish{TEventType}(TEventType)"/>
        public void Publish<TEventType>(TEventType publisher)
        {
            var subsriberType = typeof(ISubscriber<>).MakeGenericType(typeof(TEventType));

            var subscribers = GetSubscriberList(subsriberType);

            var subsribersToBeRemoved = new List<WeakReference>();

            foreach (var weakSubsriber in subscribers)
            {
                if (weakSubsriber.IsAlive)
                {
                    InvokeSubscriberEvent(
                        publisher,
                        (ISubscriber<TEventType>)weakSubsriber.Target
                    );
                }
                else
                {
                    subsribersToBeRemoved.Add(weakSubsriber);
                }
            }

            if (subsribersToBeRemoved.Any())
            {
                lock (_syncRoot)
                {
                    foreach (var remove in subsribersToBeRemoved)
                    {
                        subscribers.Remove(remove);
                    }
                }
            }
        }

        /// <inheritdoc cref="IEventAggregator.Subscribe(object)"/>
        public void Subscribe(object subscriber)
        {
            if(subscriber is null)
            {
                throw new ArgumentNullException(nameof(subscriber));
            }

            lock (_syncRoot)
            {
                var subsriberTypes = subscriber
                    .GetType()
                    .GetInterfaces()
                    .Where(i => i.IsGenericType &&
                           i.GetGenericTypeDefinition() == typeof(ISubscriber<>)
                     );

                var weakReference = new WeakReference(subscriber);

                foreach (var subsriberType in subsriberTypes)
                {
                    var subscribers = GetSubscriberList(subsriberType);

                    subscribers.Add(weakReference);
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

        private List<WeakReference> GetSubscriberList(Type subsriberType)
        {
            lock (_syncRoot)
            {
                var isFound = eventSubsribers.TryGetValue(subsriberType, out var subsribersList);

                if (!isFound)
                {
                    subsribersList = new List<WeakReference>();

                    eventSubsribers.Add(subsriberType, subsribersList);
                }

                return subsribersList;
            }
        }
    }
}
