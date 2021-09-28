using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace REST.Demo.Models
{
    public class CommentDto
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public int StoryId { get; set; }

        public int CommenterId { get; set; }
    }
}
