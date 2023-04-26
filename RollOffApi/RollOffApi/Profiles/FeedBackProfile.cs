using AutoMapper;
using RollOffApi.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RollOffApi.Profiles
{
    public class FeedBackProfile:Profile
    {
        public FeedBackProfile()
        {
            CreateMap<FeedbackForm, FeedBackDTO>().ReverseMap();
        }
    }
}
