using AutoMapper;
using Habit.Core;
using Habit.Core.RepositoryContract;
using Habit.Core.ServiceContract;
using Habit.Repository.Helpers;
using Habit.Services.DTOs;
using ReHabit.Api.DTOs;
using ReHabit.Api.Helpers;
using ReHabit.Habit.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Habit.Services
{
    public class HabitService : IHabitService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public HabitService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<HabitDto>> GetAllHabits(int userId)
        {
            var res = await _unitOfWork.Habits.GetAllHabitsAsync(userId);
            var result = _mapper.Map<List<HabitDto>>(res);
            return result;
        }

        public async Task<IEnumerable<HabitDto>> GetHabitsNotCompleted(int userId)
        {
            var res = await _unitOfWork.Habits.GetHabitsNotCompleted(userId);
            var result = _mapper.Map<List<HabitDto>>(res);
            return result;
        }
        public async Task<ResultDto> CreateHabit(int userId, CreateHabitDto newHabit)
        {
            HabitModel habit = new HabitModel
            {
                UserId = userId,
                HabitName = newHabit.HabitName,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Description = newHabit.HabitDescryption,
                CurrentStreak = 0,
                LastCompletedDate = null,
                MaxStreak = 0,
            };

            await _unitOfWork.Habits.AddAsync(habit);
            await _unitOfWork.SaveChangesAsync();

            return new ResultDto
            {
                Success = true,
                Message = "Habit created successfully"
            };
        }
        public async Task<ResultDto> UpdateHabit(int id ,UpdateHabitDto habit)
        {
            var existingHabit = await _unitOfWork.Habits.GetByIdAsync(id);
            if (existingHabit == null)
                throw new Exception("Habit not found");

            existingHabit.HabitName = habit.Name ?? existingHabit.HabitName;
            existingHabit.Description = habit.Description ?? existingHabit.Description;
            existingHabit.UpdatedAt = DateTime.UtcNow;
            await _unitOfWork.Habits.UpdateAsync(existingHabit);
            await _unitOfWork.SaveChangesAsync();

            return new ResultDto
            {
                Success = true,
                Message = "Habit updated successfully"
            };
        }
        public async Task<ResultDto> DeleteHabit(int habitId)
        {
            var existingHabit = await _unitOfWork.Habits.GetByIdAsync(habitId);

            if (existingHabit == null)
                return new ResultDto
                {
                    Success = false,
                    Message = "Habit not found"
                };

            await _unitOfWork.Habits.DeleteAsync(existingHabit);
            await _unitOfWork.SaveChangesAsync();
            return new ResultDto
            {
                Success = true,
                Message = "Habit deleted successfully"
            };
        }
    }
}
