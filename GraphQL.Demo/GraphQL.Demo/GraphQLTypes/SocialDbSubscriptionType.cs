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
    public class SocialDbSubscriptionType
    {
        [Subscribe]
        [Topic("UserAdded")]
        public User UserAdded([EventMessage] User user) => user;
    }

}
