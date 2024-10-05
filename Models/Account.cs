using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace API.Models
{
    public class Account
    {
        public string Id { get; set; } = string.Empty;

        public string Account_name { get; set; } = string.Empty;

        public string? Email { get; set; }

        public string Password { get; set; } = string.Empty;

        public int Account_role { get; set; }

        public DateTime? Date_of_birth { get; set; }

        public DateTime? Created_at { get; set; }

        public DateTime? Deleted_at { get; set; }

        public DateTime? Updated_at { get; set; } 
    }
}