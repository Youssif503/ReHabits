using Microsoft.AspNetCore.Http;
using ReHabit.Habit.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Habit.Core.ServiceContract
{
    public interface IUserService
    {
        Task<string?> UploadUserImageProfile(int userId, IFormFile image);
    }
}
