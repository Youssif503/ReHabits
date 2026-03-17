using Habit.Core.RepositoryContract;
using Habit.Repository.Data;
using Microsoft.EntityFrameworkCore;
using ReHabit.Habit.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Habit.Repository.Repository
{
    public class HabitRepository:IHabitRepository
    {
        private readonly ApplicationDbContext _context;
        public HabitRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(HabitModel model)
        {
            await _context.AddAsync(model);
        }
        public async Task<HabitModel> GetByIdAsync(int id)
        {
            var res = await _context.Habits.FindAsync(id);
            return res;
        }

        public Task<IQueryable<HabitModel>> GetAllHabitsAsync(int userId)
        {
            var res =  _context.Habits.Where(ha=>ha.UserId == userId);
            return Task.FromResult(res);
        }
        public async Task<Func<IQueryable<HabitModel>>> GetHabitsNotCompleted(int userId)
        {
            DateOnly today = DateOnly.FromDateTime(DateTime.UtcNow);
            var result =  _context.Habits.Where(h => h.UserId == userId && h.LastCompletedDate != today).AsNoTracking;
            return result;
        }
        public async Task DeleteAsync(HabitModel habitModel)
        {
            _context.Remove(habitModel);
        }

        public async Task UpdateAsync(HabitModel model)
        {
            _context.Update(model);
        }
    }
}
