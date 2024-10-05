using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos.Account
{
    public class LoginDto
    {
        [Required]
        public string Id { get; set; } = string.Empty;

        public string Account_password { get; set; } = string.Empty;
    }
}