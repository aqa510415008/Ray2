﻿using Microsoft.Extensions.Logging;
using Orleans.Runtime;
using Ray2.EventSources;
using Ray2.MQ;
using System;
using System.Threading.Tasks;

namespace Ray2.EventProcess
{
    public class EventProcessDispatch : IEventProcessDispatch
    {
        private readonly ILogger logger;
        private readonly IServiceProvider serviceProvider;
        public EventProcessDispatch(ILogger<EventProcessDispatch> logger,IServiceProvider serviceProvider)
        {
            this.logger = logger;
            this.serviceProvider = serviceProvider;
        }
        public async Task<bool> Notice(EventSubscribeInfo info, EventPublishMessage message)
        {
            try
            {
                //get processor
                var eventProcessor = this.serviceProvider.GetRequiredServiceByName<IEventProcessor>(info.Group);
                if (message.Event is IEvent @event)
                {
                    await eventProcessor.Tell(@event);
                    return true;
                }
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, $"{info.Group}.{info.Topic}->{ message.TypeCode } process failed");
            }
            return false;
        }
    }
}
