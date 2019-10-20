﻿using System;

namespace Notification.Concerns
{
    /// <summary>
    /// Base request interface for all types of notifications
    /// </summary>
    public interface INotificationRequest
    {
        int Id { get; set; }
        string Subject { get; set; }
        DateTime SendTime { get; set; }
    }

    public interface INotificationRequest<T> : INotificationRequest
    {
        T AgentDetails { get; set; }
    }
}
