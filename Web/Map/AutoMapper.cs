using AutoMapper;
using Entity.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.DTOS;

namespace Web.Map
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<Users, SignUpDto>();
            CreateMap<SignUpDto, Users>();
        }
    }
}