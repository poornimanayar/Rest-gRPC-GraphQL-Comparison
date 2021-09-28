using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace gRPC.Demo.Models
{
    public class Comment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Description { get; set; }

        public int StoryId { get; set; }

        public int CommenterId { get; set; }

        public Story Story { get; set; }

        public User Commenter { get; set; }
    }
}
