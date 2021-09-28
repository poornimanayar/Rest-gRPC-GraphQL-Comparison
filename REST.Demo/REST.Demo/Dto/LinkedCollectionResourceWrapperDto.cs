using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST.Demo.Dto
{
    public class LinkedCollectionResourceWrapperDto<T> : LinkResourceBaseDto
         where T : LinkResourceBaseDto
    {
        public IEnumerable<T> Value { get; set; }

        public LinkedCollectionResourceWrapperDto(IEnumerable<T> value)
        {
            this.Value = value;
        }
    }
}
