using AutoMapper;
using SignalR.DtoLayer.BookingDto;
using SignalRApi.Controllers.DAL.Entities;

namespace SignalRApi.Mapping;

public class BookingMapping:Profile
{
	public BookingMapping()
	{
		CreateMap<Booking, ResultBookingDto>().ReverseMap();
		CreateMap<Booking, CreateBookingDto>().ReverseMap();
		CreateMap<Booking, GetBookingDto>().ReverseMap();
		CreateMap<Booking, UpdateBookingDto>().ReverseMap();

	}
}
