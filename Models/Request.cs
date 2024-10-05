using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace API.Models
{
    [PrimaryKey(nameof(Id))]
    public class Request
    {
        public int Id { get; set; }
        public int Product_id { get; set; }
        public int Duration { get; set; }
        public bool? Is_approved { get; set; }
        public string? Approved_by { get; set; }
        public DateTime? Approved_at { get; set; }
        public DateTime? Created_at { get; set; }
        public DateTime? Deleted_at { get; set; }
        public DateTime? Updated_at { get; set; }
    }
}