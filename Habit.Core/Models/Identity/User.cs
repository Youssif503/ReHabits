using Microsoft.AspNetCore.Identity;
namespace ReHabit.Habit.Core.Models
{
    public class User:IdentityUser
    {
        public string FullName { get; set; }
        public string? ImageUrl { get; set; }
        public string? PhoneNumber { get; set; }
        public List<HabitModel>? Habits { get; set; } = new List<HabitModel>();
    }
}
