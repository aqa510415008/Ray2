﻿using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ray2.RabbitMQ
{
    public interface IRabbitChannel
    {
        IModel Model { get; }
    }
}
