﻿using Microsoft.Extensions.DependencyInjection;
using Orleans;
using System;
using System.Threading.Tasks;

namespace Ray2.EventProcess
{
    public class EventProcessorGrainDispatch : IEventProcessor
    {
        private readonly string _grainClassName;
        private readonly IServiceProvider _serviceProvider;
        private readonly IGrainFactory grainFactory;
        public EventProcessorGrainDispatch(string grainClassName, IServiceProvider serviceProvider)
        {
            this._grainClassName = grainClassName;
            this._serviceProvider = serviceProvider;
            this.grainFactory = serviceProvider.GetRequiredService<IGrainFactory>();
        }
        public Task Tell(IEvent @event)
        {
            object id = @event.GetStateId();
            IEventProcessor eventProcessor;
            if (id is Guid _guid)
            {
                eventProcessor = grainFactory.GetGrain<IEventProcessor>(primaryKey: _guid, grainClassNamePrefix: _grainClassName);
            }
            else if (id is string _strId)
            {
                eventProcessor = grainFactory.GetGrain<IEventProcessor>(primaryKey: _strId, grainClassNamePrefix: _grainClassName);
            }
            else
            {
                eventProcessor = grainFactory.GetGrain<IEventProcessor>(primaryKey: (long)id, grainClassNamePrefix: _grainClassName);
            }
            return eventProcessor.Tell(@event);
        }
    }
}
