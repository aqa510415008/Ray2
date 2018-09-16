﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Ray2.Storage
{
    public class EventStorageModel
    {
        public EventStorageModel(string stateId, IEvent @event)
        {
            this.StateId = stateId;
            this.Event = @event;
        }
        public IEvent Event { get; }
        public string StateId { get; }
    }
}
