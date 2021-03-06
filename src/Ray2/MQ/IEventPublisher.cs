﻿using Ray2.EventSource;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ray2.MQ
{
    /// <summary>
    /// this is the event publish  interface
    /// </summary>
    public interface IEventPublisher
    {
        /// <summary>
        /// Publish a message to the message queue
        /// </summary>
        /// <param name="topic">topic</param>
        /// <param name="model">Event object</param>
        /// <returns></returns>
        Task<bool> Publish(string topic, EventModel model);
    }
}
