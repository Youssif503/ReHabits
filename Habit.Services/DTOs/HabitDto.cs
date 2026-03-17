namespace ReHabit.Api.DTOs
{
    public class HabitDto
    {
        public int HabitId { get; set; }
        public string HabitName { get; set; }
        public DateOnly CreatedAt { get; set; }
        public int Streak { get; set; }
        public bool IsCompletedToday { get; set; }

    }
}
