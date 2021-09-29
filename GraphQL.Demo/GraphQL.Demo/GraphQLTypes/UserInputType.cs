using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.Demo.Models
{
    public class UserInput
    {
        public string Name { get; set; }

        public string Headline { get; set; }
    }   
}
