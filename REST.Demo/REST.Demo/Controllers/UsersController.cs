using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using REST.Demo.Dto;
using REST.Demo.DTO;
using REST.Demo.Models;
using REST.Demo.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace REST.Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly UsersRepository _usersRepository;

        private readonly IMapper _mapper;

        public UsersController(IMapper mapper, UsersRepository usersRepository)
        {
            _mapper = mapper;
            _usersRepository = usersRepository;
        }

        // GET: api/<UsersController>
        [HttpGet(Name = nameof(GetUsers))]
        [HttpHead]
        public ActionResult<IEnumerable<UserDto>> GetUsers()
        {
            var users = _usersRepository.GetUsers();

            var userList = _mapper.Map<IEnumerable<UserDto>>(users);

            userList = userList.Select(user => this.CreateLinksForUser(user));

            var wrapper = new LinkedCollectionResourceWrapperDto<UserDto>(userList);

            //return 200 status code with a response body
            return this.Ok(this.CreateLinksForUser(wrapper));
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}", Name = nameof(GetUserById))]
        public ActionResult<UserDto> GetUserById(int id)
        {
            if (id == default)
            {
                return BadRequest();
            }

            var user = _usersRepository.GetUserById(id);

            if (user == null)
            {
                return NotFound();
            }

            var mappedUser = _mapper.Map<UserDto>(user);

            //return 200 status code with a response body containing the details of the user
            return Ok(CreateLinksForUser(mappedUser));
        }

        // POST api/<UsersController>
        [HttpPost(Name = nameof(CreateUser))]
        public ActionResult<UserDto> CreateUser([FromBody] CreateUserDto user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            var mappedUser = _mapper.Map<User>(user);
            var createdUser = _usersRepository.AddUser(mappedUser);

            var mappedNewUser = _mapper.Map<UserDto>(createdUser);

            //return 201 Created status code with a response body and URI of the user at the location header
            return CreatedAtAction(nameof(GetUserById), new { id = mappedNewUser.Id }, CreateLinksForUser(mappedNewUser));
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}", Name = nameof(UpdateUser))]
        public ActionResult UpdateUser(int id, [FromBody] UpdateUserDto user)
        {

            if (user == null)
            {
                //return 400 when no request body
                return BadRequest();
            }

            if (id != user.Id)
            {

                //return 400 status code when ids dont match
                return BadRequest();
            }

            var mappedUser = _mapper.Map<User>(user);

            if (!_usersRepository.CheckUserExists(mappedUser.Id))
            {
                //return 404 when no such user found
                return NotFound();
            }

            var updated = _usersRepository.UpdateUser(mappedUser);

            if(updated == default)
            {
                //return 409 cant update because of conflict
                return Conflict();
            }

            // return no content 204
            return NoContent();

        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}", Name = nameof(DeleteUser))]
        public ActionResult DeleteUser(int id)
        {
            if(id == default)
            {
                // 400 for no id
                return BadRequest();
            }

            var user = _usersRepository.GetUserById(id);

            if(user== null)
            {
                //return 404 when no such user found
                return NotFound();
            }

            var deleted = _usersRepository.DeleteUser(user);

           // return no content 204
            return NoContent();
        }

        

        private UserDto CreateLinksForUser(UserDto user)
        {
            var idObj = new { id = user.Id };
            user.Links.Add(
                new LinkDto(Url.Link(nameof(this.GetUserById), idObj),
                "self",
                "GET"));           

            user.Links.Add(
                new LinkDto(Url.Link(nameof(this.UpdateUser), idObj),
                "update-user",
                "PUT"));

            user.Links.Add(
                new LinkDto(Url.Link(nameof(this.DeleteUser), idObj),
                "delete-user",
                "DELETE"));

            user.Links.Add(
               new LinkDto(Url.Link(nameof(UsersStoriesController.GetStoriesForUser), idObj),
               "user-stories",
               "GET"));

            return user;
        }

        private LinkedCollectionResourceWrapperDto<UserDto> CreateLinksForUser(
            LinkedCollectionResourceWrapperDto<UserDto> usersWrapper)
        {
            usersWrapper.Links.Add(
                new LinkDto(Url.Link(nameof(this.GetUsers), new { }),
                "self",
                "GET"));

            return usersWrapper;
        }
    }
}
