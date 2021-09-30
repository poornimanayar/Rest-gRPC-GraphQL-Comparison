using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using REST.Demo.Dto;
using REST.Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace REST.Demo.Controllers
{
    //id is the user id
    [Route("api/Users/{id}/Stories")]
    [ApiController]
    public class UsersStoriesController : ControllerBase
    {
        private readonly IMapper _mapper;

        public UsersStoriesController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet(Name = nameof(GetStoriesForUser))]
        [HttpHead]
        public ActionResult<IEnumerable<StoryDto>> GetStoriesForUser(int id)
        {
            var jsonString = System.IO.File.ReadAllText(@"C:\WORK\SPEAKERDEMOS\REST-gRPC-GRAPHQL-COMPARISON\REST.Demo\REST.Demo\Data\stories.json");

            var stories = JsonSerializer.Deserialize<List<Story>>(jsonString, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

            var storiesByUser = stories.Where(s => s.StoryOwnerId == id);

            var mappedStories = _mapper.Map<IEnumerable<StoryDto>>(storiesByUser);

            mappedStories = mappedStories.Select(story => this.CreateLinksForStory(story));
           

            //return 200 status code with a response body
            return this.Ok(mappedStories);
        }

        private StoryDto CreateLinksForStory(StoryDto story)
        {
            var idObj = new { id = story.Id };
            story.Links.Add(
                new LinkDto(Url.Link(nameof(StoriesController.GetStory), idObj),
                "self",
                "GET"));

            story.Links.Add(
               new LinkDto(Url.Link(nameof(StoriesController.GetCommentsByStory), idObj),
               "story-comments",
               "GET"));

            return story;
        }

        private LinkedCollectionResourceWrapperDto<StoryDto> CreateLinksForStory(
            LinkedCollectionResourceWrapperDto<StoryDto> storiesWrapper)
        {
            storiesWrapper.Links.Add(
                new LinkDto(Url.Link(nameof(this.GetStoriesForUser), new { }),
                "self",
                "GET"));

            return storiesWrapper;
        }
    }
}
