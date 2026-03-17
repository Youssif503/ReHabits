using Habit.Core;
using Habit.Core.ServiceContract;
using Habit.Services.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReHabit.Api.DTOs;
namespace ReHabit.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class HabitController : ControllerBase
    {
        private readonly IHabitService _habitService;
        public HabitController(IHabitService habitService)
        {
            _habitService = habitService;
        }
        [HttpGet]
        public async Task<IActionResult> GetHabits()
        {
            //int userId = User.Claims.FirstOrDefault(c => c.Type == "id")?.Value;
            var res = await _habitService.GetAllHabits(1);
            return Ok(res);
        }
        [HttpGet]
        public async Task<IActionResult> GetHabit_notCompleted()
        {
            //int userId = User.Claims.FirstOrDefault(c => c.Type == "id")?.Value;
            var result = await _habitService.GetHabitsNotCompleted(1);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateHabit(CreateHabitDto habitDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //int userId = User.Claims.FirstOrDefault(c => c.Type == "id")?.Value;

            var res = await _habitService.CreateHabit(1, habitDto);

            if (!res.Success)
                return BadRequest(res);

            return Ok(res.Message);
        }
        [HttpPut("{Id:int}")]
        public async Task<IActionResult> UpdateHabit(int Id,UpdateHabitDto habitDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var res = await _habitService.UpdateHabit(Id , habitDto);

            if (!res.Success)
                return BadRequest(res);

            return Ok(res.Message);
        }
        [HttpDelete("delete/{Id:int}")]
        public async Task<IActionResult> DeleteHabit([FromRoute] int habitId)
        {
           var result = await _habitService.DeleteHabit(habitId);
           if(!result.Success)
                return BadRequest(result);

           return Ok(result.Message);
        }
    }
}
