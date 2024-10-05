using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos.Request
{
    public class CreateRequestDto
    {
        public int Product_id { get; set; }
        public int Duration { get; set; }
    }
}