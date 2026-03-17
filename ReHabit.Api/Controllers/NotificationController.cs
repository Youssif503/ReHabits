using Habit.Services.ServiceContract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReHabit.Api.Dtos;

namespace ReHabit.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;
        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpPost("-send")]
        public async Task<IActionResult> SendNotification(MeassageDto messageDto)
        {
            var result = await _notificationService.SendNotificationAsync(messageDto.toNumber, messageDto.Body);

            if(string.IsNullOrEmpty(result.ErrorMessage))
                return BadRequest(result.ErrorMessage);

            return Ok("Notification sent successfully");
        }

    }
}
