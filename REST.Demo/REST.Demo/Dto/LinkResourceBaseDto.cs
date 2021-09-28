using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST.Demo.Dto
{
    public class LinkResourceBaseDto
    {
        public List<LinkDto> Links { get; set; } = new List<LinkDto>();
    }
}
