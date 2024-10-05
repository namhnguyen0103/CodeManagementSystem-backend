using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos.Request
{
    public class RequestDto
    {
        public int Id { get; set; }
        public int Product_id { get; set; }
        public string Product_name { get; set; } = string.Empty;
        public string Customer_id { get; set; } = string.Empty;
        public string Customer_name { get; set; } = string.Empty;
        public string OldActivationCode { get; set; } = string.Empty;
        public DateTime? OldExpirationDate { get; set; }
        public DateTime? NewExpirationDate { get; set; }
        public int Duration { get; set; }
        public bool? IsApproved { get; set; }
        public string? ApprovedBy { get; set; }
        public DateTime? Created_at { get; set; }
    }
}