using JobsForAll.Domain.Models;
using JobsForAll.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace FinalProjectApp
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Chat, ChatViewModel>().ReverseMap();
        }

    }
}
