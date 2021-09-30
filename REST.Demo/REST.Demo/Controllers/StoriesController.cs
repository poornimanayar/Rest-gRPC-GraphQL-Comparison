using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using REST.Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace REST.Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoriesController : ControllerBase
    {
        private readonly IMapper _mapper;

        public StoriesController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet("{id}", Name = nameof(GetStory))]
        [HttpHead]
        public ActionResult<StoryDto> GetStory(int id)
        {
            var jsonString = System.IO.File.ReadAllText(@"C:\WORK\SPEAKERDEMOS\REST-gRPC-GRAPHQL-COMPARISON\REST.Demo\REST.Demo\Data\stories.json");

            var stories = JsonSerializer.Deserialize<List<StoryDto>>(jsonString, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

            var mappedStory = _mapper.Map<StoryDto>(stories.FirstOrDefault(s => s.Id== id));

            //return 200 status code with a response body
            return this.Ok(mappedStory);
        }

        [HttpGet("{id}/comments", Name = nameof(GetCommentsByStory))]
        [HttpHead]
        public ActionResult<CommentDto> GetCommentsByStory(int id)
        {
            var jsonString = System.IO.File.ReadAllText(@"C:\WORK\SPEAKERDEMOS\REST-gRPC-GRAPHQL-COMPARISON\REST.Demo\REST.Demo\Data\comments.json");

            var comments = JsonSerializer.Deserialize<List<Comment>>(jsonString, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

            var mappedComments = _mapper.Map<IEnumerable<CommentDto>>(comments.Where(c => c.StoryId == id));

            //return 200 status code with a response body
            return this.Ok(mappedComments);
        }
    }
}
