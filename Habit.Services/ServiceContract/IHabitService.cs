using Habit.Repository.Helpers;
using Habit.Services.DTOs;
using ReHabit.Api.DTOs;
using ReHabit.Habit.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Habit.Core.ServiceContract
{
    public interface IHabitService
    {
        Task<IEnumerable<HabitDto>> GetAllHabits(int userId);
        Task<IEnumerable<HabitDto>> GetHabitsNotCompleted(int userId);
        Task<ResultDto> CreateHabit(int userId, CreateHabitDto newHabit);
        Task<ResultDto> UpdateHabit(int Id,UpdateHabitDto habit);
        Task<ResultDto> DeleteHabit(int habitId);
    }
}
