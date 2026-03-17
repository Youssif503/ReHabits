using Habit.Services.ServiceContract;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
using ReHabit.Api.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace Habit.Services
{
    public class NotificationService : INotificationService
    {
        private readonly twilio _twillo;
        public NotificationService(IOptions<twilio> twillo)
        {
            _twillo = twillo.Value;
        }
        public async Task<MessageResource> SendNotificationAsync(string to, string message)
        {
            TwilioClient.Init(_twillo.AccountSid, _twillo.AuthToken);
            var messageOptions =  await MessageResource.CreateAsync(
                body: message,
                from: new Twilio.Types.PhoneNumber(_twillo.FromPhoneNumber),
                to : new Twilio.Types.PhoneNumber(to)
            );

            return messageOptions;
        }
    }
}
