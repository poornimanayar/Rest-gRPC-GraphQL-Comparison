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

        //name of the query is the name of the method with the "Get" omitted out
        public List<User> GetUsers( [Service] UsersRepository repository)
        {
            return repository.GetUsers();
        }

        public User GetUser(int id, [Service] UsersRepository repository)
        {
            return repository.GetUserById(id);
        }
    }

}
