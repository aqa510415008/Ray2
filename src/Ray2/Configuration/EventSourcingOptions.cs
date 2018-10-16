﻿using Ray2.Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ray2.Configuration
{
    public class EventSourcingOptions
    {
        public EventSourcingOptions(EventSourcingAttribute attr)
        {
            this.EventSourcingName = attr.Name;
        }
        public string EventSourcingName { get; set; }
        public SnapshotOptions SnapshotOptions { get; set; }
        public StorageOptions StorageOptions { get; set; }
    }
}
