using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using REST.Demo.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST.Demo.Controllers
{
    [Route("api")]
    [ApiController]

    public class RootController : ControllerBase
    {
        [HttpGet(Name = nameof(GetRoot))]
        public ActionResult GetRoot()
        {
            var output = new RootDto
            {
                Users = new RootLinkDto(Url.Link(nameof(UsersController.GetUsers), new { }),
               "[collection]", "Get all users")
            };

            return Ok(output);
        }
    }
}
