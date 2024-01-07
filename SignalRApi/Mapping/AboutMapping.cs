﻿using AutoMapper;
using SignalR.DtoLayer.AboutDto;
using SignalRApi.Controllers.DAL.Entities;

namespace SignalRApi.Mapping;

public class AboutMapping:Profile
{
    public AboutMapping()
    {
        CreateMap<About, ResultAboutDto>().ReverseMap();
        CreateMap<About, CreateAboutDto>().ReverseMap();
        CreateMap<About, GetAboutDto>().ReverseMap();
        CreateMap<About, UpdateAboutDto>().ReverseMap();
    }
}
