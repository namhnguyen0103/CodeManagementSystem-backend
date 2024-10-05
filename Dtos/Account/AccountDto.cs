using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos.Account
{
    public class AccountDto
    {
        public string Id { get; set; } = string.Empty;

        public string Account_name { get; set; } = string.Empty;

        public string? Email { get; set; }

        public int Account_role { get; set; }

        public DateTime? Date_of_birth { get; set; }

    }

    public class AdminAccountDto
    {
        public string AdminId { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string? Email { get; set; }

        public bool SuperAdmin { get; set; }

        public DateTime? Date_of_birth { get; set; }
    }
}