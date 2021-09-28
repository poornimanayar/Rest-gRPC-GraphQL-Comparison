using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace REST.Demo.Models
{
    public class StoryDto
    {
        public int Id { get; set; }

        public int StoryOwnerId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

    }
}
