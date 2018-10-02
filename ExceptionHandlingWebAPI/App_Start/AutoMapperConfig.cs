using AutoMapper;
using StackExchange.StacMan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExceptionHandlingWebAPI.App_Start
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize((config) =>
            {
                config.CreateMap<Tag, ExceptionHandlingWebAPI.Models.Tag>().ForMember(des => des.TotalCount, opt => opt.MapFrom(src => src.Count));
            });
        }
    }
}