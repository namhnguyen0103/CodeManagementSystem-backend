using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos.Request
{
    public class UpdateRequestDto
    {
        public int Id { get; set; }
        public bool? IsApproved { get; set; }
        public string? ApprovedBy { get; set; }
    }
}