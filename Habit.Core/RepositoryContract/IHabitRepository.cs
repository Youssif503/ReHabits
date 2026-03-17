using ReHabit.Habit.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Habit.Core.RepositoryContract
{
    public interface IHabitRepository
    {
        Task<IQueryable<HabitModel>> GetAllHabitsAsync(int userId);
        Task<Func<IQueryable<HabitModel>>> GetHabitsNotCompleted(int userId);
        Task<HabitModel> GetByIdAsync(int id);
        Task AddAsync(HabitModel model);
        Task UpdateAsync(HabitModel model);
        Task DeleteAsync(HabitModel model);
    }
}
