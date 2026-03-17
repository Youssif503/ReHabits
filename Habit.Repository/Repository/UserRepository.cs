using Habit.Core;
using Habit.Core.RepositoryContract;
using Habit.Repository.Data;
using Habit.Repository.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using ReHabit.Habit.Core.Models;
using System;
namespace Habit.Repository.Repository
{
    public class UserRepository : BaseRepository<User> ,IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task UploadUserProileImage(User user,string imageUrl)
        {
            try
            {
                user.ImageUrl = imageUrl;
                _context.Update(user);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
