﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DtoLayer.BookingDto;
using SignalRApi.Controllers.DAL.Entities;

namespace SignalRApi.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class BookingController : ControllerBase
{
    private readonly IBookingService _bookingService;

    public BookingController(IBookingService bookingService)
    {
        _bookingService = bookingService;
    }

    [HttpGet]
    public IActionResult BookingList()
    {
        var values = _bookingService.TGetListAll();
        return Ok(values);
    }

    [HttpPost]
    public IActionResult CreateBooking(CreateBookingDto createBookingDto)
    {
        Booking booking = new Booking()
        {
            Mail = createBookingDto.Mail,
            DateTime = createBookingDto.DateTime,
            Name = createBookingDto.Name,
            PersonCount = createBookingDto.PersonCount,
            Phone = createBookingDto.Phone
        };
        _bookingService.TAdd(booking);
        return Ok("Rezervasyon yapıldı.");
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteBooking(int id)
    {
        var value = _bookingService.TGetById(id);
        _bookingService.TDelete(value);
        return Ok("Rezervasyon silindi.");
    }

    [HttpPut]
    public IActionResult UpdateBooking(UpdateBookingDto updateBookingDto)
    {
        Booking booking = new Booking()
        {
            Mail = updateBookingDto.Mail,
            DateTime = updateBookingDto.DateTime,
            Name = updateBookingDto.Name,
            PersonCount = updateBookingDto.PersonCount,
            Phone = updateBookingDto.Phone
        };
        _bookingService.TUpdate(booking);
        return Ok("Rezervasyon güncellendi.");
    }

    [HttpGet("{id}")]
    public IActionResult GetBooking(int id)
    {
        var value = _bookingService.TGetById(id);
        return Ok(value);
    }
}
