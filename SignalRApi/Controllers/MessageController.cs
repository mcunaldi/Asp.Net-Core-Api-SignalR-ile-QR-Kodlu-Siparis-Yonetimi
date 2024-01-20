using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.MessageDto;
using SignalR.EntityLayer.Entities;
using SignalRApi.Controllers.DAL.Entities;

namespace SignalRApi.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class MessageController : ControllerBase
{
    private readonly IMessageService _messageService;

    public MessageController(IMessageService messageService)
    {
        _messageService = messageService;
    }

    [HttpGet]
    public IActionResult MessagetList()
    {
        var values = _messageService.TGetListAll();
        return Ok(values);
    }

    [HttpPost]
    public IActionResult CreateMessage(CreateMessageDto createMessageDto)
    {
        Message message = new Message()
        {
            Mail = createMessageDto.Mail,
            MessageContent = createMessageDto.MessageContent,
            NameSurname = createMessageDto.NameSurname,
            Phone = createMessageDto.Phone,
            Status = false,
            MessageSendDate = DateTime.Now,
            Subject = createMessageDto.Subject

        };

        _messageService.TAdd(message);
        return Ok("Mesaj başarılı bir şekilde gönderildi.");
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteMessage(int id)
    {
        var value = _messageService.TGetById(id);
        _messageService.TDelete(value);
        return Ok("Mesaj silindi.");
    }

    [HttpGet("{id}")]
    public IActionResult GetMessage(int id)
    {
        var value = _messageService.TGetById(id);
        return Ok(value);
    }

    [HttpPut]
    public IActionResult UpdateMessage(UpdateMessageDto updateMessageDto)
    {

        Message message = new Message()
        {
            Mail = updateMessageDto.Mail,
            MessageContent = updateMessageDto.MessageContent,
            NameSurname = updateMessageDto.NameSurname,
            Phone = updateMessageDto.Phone,
            Status = false,
            MessageSendDate = DateTime.Now,
            Subject = updateMessageDto.Subject,
            MessageId = updateMessageDto.MessageId
        };


        _messageService.TUpdate(message);
        return Ok("Mesaj güncellendi.");
    }
}
