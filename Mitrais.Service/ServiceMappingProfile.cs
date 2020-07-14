using AutoMapper;
using Mitrais.Data.Domain;
using Mitrais.Data.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mitrais.Service
{
    public class ServiceMappingProfile : Profile
    {
        public ServiceMappingProfile()
        {
            CreateMap<PostUser, User>();
        }
    }
}
