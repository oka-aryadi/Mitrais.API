using AutoMapper;
using Mitrais.API.ViewModel;
using Mitrais.Data.Domain;
using Mitrais.Data.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mitrais.API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserViewModel>();
            CreateMap<Gender, GenderViewModel>();
        }
    }
}
