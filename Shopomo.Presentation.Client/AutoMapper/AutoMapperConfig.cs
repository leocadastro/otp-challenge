using AutoMapper;
using Shopomo.OTP.Domain.Entities;
using Shopomo.Presentation.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shopomo.Presentation.Client.AutoMapper
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(x =>
            {
                x.CreateMap<User, UserViewModel>();
                x.CreateMap<UserViewModel, User>();
            });
        }
    }
}