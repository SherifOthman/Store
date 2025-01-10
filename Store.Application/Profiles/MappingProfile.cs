using AutoMapper;
using Store.Application.Fetures.Usres.Commands.Register;
using Store.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Profiles;
public class MappingProfile : Profile
{
    public MappingProfile()
    {

        CreateMap<RegisterCommand, User>()
            .ForMember(dest => dest.PasswordHashed, src => src.MapFrom(src => src.Password));
    }
}
