using AutoMapper;
using ReHabit.Api.DTOs;
using ReHabit.Habit.Core.Models;
namespace ReHabit.Api.Helpers
{
    public class Mapper:Profile
    {
        Mapper()
        {
            var DateOnlyToday = DateOnly.FromDateTime(DateTime.Now);
            CreateMap<HabitModel, HabitDto>()
                .ForMember(dest => dest.HabitName, src => src.MapFrom(src => src.HabitName))
                .ForMember(dest => dest.CreatedAt, src => src.MapFrom(src => src.CreatedAt))
                .ForMember(dest => dest.Streak, src => src.MapFrom(src => src.CurrentStreak))
                .ForMember(dest => dest.IsCompletedToday, src => src.MapFrom(src => src.LastCompletedDate == DateOnlyToday ? true:false))
                .ReverseMap();      
        }
    }
}
