using GraphQL.Demo.Models;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.Demo.GraphQLTypes
{
    public class UserType : ObjectType<User>
    {
        protected override void Configure(IObjectTypeDescriptor<User> descriptor)
        {
            descriptor
                .Field(f => f.Id)
                .Type<StringType>();

            descriptor
                .Field(f => f.Name)
                .Type<StringType>();

            descriptor
               .Field(f => f.Headline)
               .Type<StringType>();
        }
    }
}
