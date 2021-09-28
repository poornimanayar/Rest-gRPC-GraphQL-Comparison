using gRPC.Demo.Protos;
using gRPC.Demo.Repository;
using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gRPC.Demo.Services
{
    public class UsersService: gRPC.Demo.Protos.User.UserBase
    {
        private readonly UsersRepository _usersRepository;

        public UsersService(UsersRepository usersRepository)
        {
            this._usersRepository = usersRepository;
        }

        public override Task<UserListReplyModel> GetUsers(UserListRequestModel request, ServerCallContext context)
        {
            var userList = _usersRepository.GetUsers();

            var userListReplyModel = new UserListReplyModel();

            var users = new List<UserReplyModel>();

            foreach (var user in userList)
            {
                users.Add(new UserReplyModel { Id = user.Id, Name = user.Name, Headline = user.Headline });
            }

            userListReplyModel.Users.AddRange(users);


            var metaData = new Metadata();

            //access request headers
            foreach (var header in context.RequestHeaders)
            {
                metaData.Add(header.Key, header.Value);
            }

            //add response headers
            context.WriteResponseHeadersAsync(metaData);

            //add response trailer
            context.ResponseTrailers.Add("my-response-trailer", "my-response-trailer-value");

            return Task.FromResult(userListReplyModel);
        }

        public override Task<UserReplyModel> GetUser(UserRequestModel request, ServerCallContext context)
        {
            return base.GetUser(request, context);
        }

        public override Task<CreateUserReplyModel> CreateUser(CreateUserRequestModel request, ServerCallContext context)
        {
            return base.CreateUser(request, context);
        }

        public override Task<UpdateUserReplyModel> UpdateUser(UpdateUserRequestModel request, ServerCallContext context)
        {
            return base.UpdateUser(request, context);
        }

        public override Task<DeleteUserReplyModel> DeleteUser(DeleteUserRequestModel request, ServerCallContext context)
        {
            return base.DeleteUser(request, context);
        }
    }
}
