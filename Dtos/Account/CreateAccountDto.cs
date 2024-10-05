using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos.Account
{
    public class CreateAccountDto
    {
        public string Id { get; set; } = string.Empty;

        public string Account_name { get; set; } = string.Empty;

        public string? Email { get; set; }

        public string Account_password { get; set; } = string.Empty;

        public DateTime? Date_of_birth { get; set; }
    }
}