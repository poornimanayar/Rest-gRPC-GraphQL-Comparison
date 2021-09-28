using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST.Demo.Dto
{
    public class RootLinkDto
    {
        public string Href { get; private set; }
        public string Rel { get; private set; }
        public string Description { get; private set; }
        public RootLinkDto(string href, string rel, string description)
        {
            this.Href = href;
            this.Rel = rel;
            this.Description = description;
        }        
    }
}
