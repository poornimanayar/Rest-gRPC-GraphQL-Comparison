using GraphQL.Demo.Database;
using GraphQL.Demo.Models;
using GraphQL.Demo.Repository;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.Demo.GraphQLTypes
{    
    public class SocialDbQueryType
    { 
        public List<User> GetUsers( [Service] UsersRepository repository)
        {
            return repository.GetUsers();
        }

        public User GetUser(int id, [Service] UsersRepository repository)
        {
            return repository.GetUserById(id);
        }

        public User CreateUser([Service] UsersRepository repository)
        {
            return repository.AddUser(new User { Name = "Peeves", Headline = "Poltergeist" });
        }
    }

}
