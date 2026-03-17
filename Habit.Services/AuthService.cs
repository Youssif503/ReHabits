using Habit.Core.ServiceContract;
using ReHabit.Habit.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Habit.Services
{
    public class AuthService : IAuthService
    {
        public Task<string> CreateTokenAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}
