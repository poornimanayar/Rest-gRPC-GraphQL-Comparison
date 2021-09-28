using AutoMapper;
using REST.Demo.DTO;
using REST.Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST.Demo.MappingProfiles
{
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<Comment, CommentDto>();
        }
    }
}
