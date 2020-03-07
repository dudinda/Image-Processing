using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

using ImageProcessing.Core.EventAggregator.Interface;
using ImageProcessing.Core.EventAggregator.Interface.Subscriber;

namespace ImageProcessing.Core.EventAggregator.Implementation
{
    /// <inheritdoc cref="IEventAggregator"/>
    public class EventAggregator : IEventAggregator
    {

        private Dictionary<Type, List<WeakReference>> eventSubsribers = new Dictionary<Type, List<WeakReference>>();

        private readonly object _syncRoot = new object();

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
                    var subscriber = (ISubscriber<TEventType>)weakSubsriber.Target;

                    InvokeSubscriberEvent<TEventType>(publisher, subscriber);
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


        private void InvokeSubscriberEvent<TEventType>(TEventType publisher, ISubscriber<TEventType> subscriber)
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
            List<WeakReference> subsribersList = null;

            lock (_syncRoot)
            {
                var isFound = eventSubsribers.TryGetValue(subsriberType, out subsribersList);

                if (!isFound)
                {
                    subsribersList = new List<WeakReference>();

                    eventSubsribers.Add(subsriberType, subsribersList);
                }
            }

            return subsribersList;
        }
    }
}
