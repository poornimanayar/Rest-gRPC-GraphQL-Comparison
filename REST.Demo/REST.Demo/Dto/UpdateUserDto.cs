using REST.Demo.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST.Demo.DTO
{
    public class UpdateUserDto 
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Headline { get; set; }
    }
}
