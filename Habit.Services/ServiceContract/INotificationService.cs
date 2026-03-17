using System;
using System.Collections.Generic;
using System.Text;
using Twilio.Rest.Api.V2010.Account;

namespace Habit.Services.ServiceContract
{
    public interface INotificationService
    {
     Task<MessageResource> SendNotificationAsync(string to, string message);
    }
}
