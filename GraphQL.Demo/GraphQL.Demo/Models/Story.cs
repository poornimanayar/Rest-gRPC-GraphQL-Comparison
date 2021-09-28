﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.Demo.Models
{
    public class Story
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int StoryOwnerId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public User StoryOwner { get; set; }

    }
}
