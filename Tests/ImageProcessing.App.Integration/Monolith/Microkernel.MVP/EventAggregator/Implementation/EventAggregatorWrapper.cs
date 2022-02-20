using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

using ImageProcessing.App.PresentationLayer.UnitTests.Fakes.Components;
using ImageProcessing.Microkernel.MVP.Aggregator.Implementation;
using ImageProcessing.Microkernel.MVP.Aggregator.Subscriber;

namespace ImageProcessing.App.PresentationLayer.IntegrationTests.Fakes
{
    internal sealed class EventAggregatorWrapper : EventAggregator, IEventAggregatorWrapper
    {
        protected override void Post(SendOrPostCallback d, object state)
        {
            SynchronizationContext.SetSynchronizationContext(new SynchronizationContextWrapper());
            SynchronizationContext.Current.Send(d, state);
        }

        /// <inheritdoc cref="IEventAggregator.PublishFromAll{TEventArgs}(object, TEventArgs)"/>
        public new void PublishFromAll<TEventArgs>(object publisher, TEventArgs args)
        {
            var subscriberType = typeof(ISubscriber<>).MakeGenericType(typeof(TEventArgs));

            foreach (var sub in GetSubscribers(subscriberType).Values.SelectMany(_ => _))
            {
                var subscriber = sub as ISubscriber<TEventArgs>;

                if (subscriber != null)
                {
                    Post(s => subscriber.OnEventHandler(publisher, args), null!);
                }
            }

        }

        private Dictionary<object, HashSet<object>> GetSubscribers(Type subsriberType)
        {
            if (!_map.TryGetValue(subsriberType, out var pubsToSubs))
            {
                pubsToSubs = new Dictionary<object, HashSet<object>>();

                _map.Add(subsriberType, pubsToSubs);
            }
            return pubsToSubs;
        }
    }
}
