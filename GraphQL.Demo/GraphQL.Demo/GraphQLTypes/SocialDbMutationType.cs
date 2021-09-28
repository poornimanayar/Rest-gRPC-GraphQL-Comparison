using GraphQL.Demo.Database;
using GraphQL.Demo.Models;
using GraphQL.Demo.Repository;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Subscriptions;
using HotChocolate.Types;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.Demo.GraphQLTypes
{    
    public class SocialDbMutationType
    {        
        public async Task<User> CreateUser(UserInput userInput,[Service] UsersRepository repository, [Service] ITopicEventSender sender)
        {
            var user = new User { Name = userInput.Name, Headline = userInput.Headline };

            var addedUser = repository.AddUser(user);

            await sender.SendAsync(nameof(SocialDbSubscriptionType.UserAdded), addedUser);

            return addedUser;

        }
    }

}
