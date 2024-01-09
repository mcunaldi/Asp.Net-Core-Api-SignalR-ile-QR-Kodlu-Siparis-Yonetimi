using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.NotificationDto;
using SignalR.EntityLayer.Entities;
using SignalRApi.Controllers.DAL.Entities;

namespace SignalRApi.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class NotificationController : ControllerBase
{
    private readonly INotificationService _notificationService;

    public NotificationController(INotificationService notificationService)
    {
        _notificationService = notificationService;
    }

    [HttpGet]
    public IActionResult NotificationList()
    {
        return Ok(_notificationService.TGetListAll());
    }

    [HttpGet]

    public IActionResult NotificationCountByStatusFalse()
    {
        return Ok(_notificationService.TNotificationCountByStatusFalse());
    }

    [HttpGet]

    public IActionResult GetAllNotificationByFalse()
    {
        return Ok(_notificationService.TGetAllNotificationByFalse());
    }

    [HttpPost]

    public IActionResult CreateNotification(CreateNotificationDto createNotificationDto)
    {
        Notification notification = new Notification()
        {
            Description = createNotificationDto.Description,
            Icon = createNotificationDto.Icon,
            Status = false,
            Type = createNotificationDto.Type,
            Date = Convert.ToDateTime(DateTime.Now.ToShortDateString())
        };

        _notificationService.TAdd(notification);
        return Ok("Ekleme işlemi başarıyla yapıldı.");
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteNotification(int id)
    {
        var value = _notificationService.TGetById(id);
        _notificationService.TDelete(value);
        return Ok("Bildirim silindi.");
    }

    [HttpGet("{id}")]
    public IActionResult GetNotification(int id)
    {
        var value = _notificationService.TGetById(id);
        return Ok(value);
    }

    [HttpPut]

    public IActionResult UpdateNotification(UpdateNotificationDto updateNotificationDto)
    {
        Notification notification = new Notification()
        {
            NotificationId = updateNotificationDto.NotificationId,
            Description = updateNotificationDto.Description,
            Icon = updateNotificationDto.Icon,
            Status = updateNotificationDto.Status,
            Type = updateNotificationDto.Type,
            Date = updateNotificationDto.Date
        };

        _notificationService.TUpdate(notification);
        return Ok("Güncelleme işlemi başarıyla yapıldı.");
    }

    [HttpGet("{id}")]
    public IActionResult NotificationStatusChangeToFalse(int id)
    {
        _notificationService.TNotificationStatusChangeToFalse(id);
        return Ok("Güncelleme yapıldı.");
    }

	[HttpGet("{id}")]
	public IActionResult NotificationStatusChangeToTrue(int id)
	{
		_notificationService.TNotificationStatusChangeToTrue(id);
		return Ok("Güncelleme yapıldı.");
	}
}
