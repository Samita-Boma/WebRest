using System;
using AutoMapper;

using WebRest.EF.Models;

namespace WebRestAPI.Code;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Address, Address>();
    }
}
