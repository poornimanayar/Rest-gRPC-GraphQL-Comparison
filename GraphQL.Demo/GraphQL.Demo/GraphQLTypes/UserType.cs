﻿using GraphQL.Demo.Models;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.Demo.GraphQLTypes
{
    public class UserType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Headline { get; set; }
    }    
}
