using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace API.Models
{
    [PrimaryKey(nameof(Id))]
    public class UserProduct
    {
        public int Id { get; set; }

        public string Customer_id { get; set; } = string.Empty;

        public int Product_id { get; set; }

        public DateTime Expiration_date { get; set; }

        public int Mid { get; set; }

        public int Sitecode { get; set; }

        public string Activation_code { get; set; } = string.Empty;

        public DateTime? Created_at { get; set; }

        public DateTime? Deleted_at { get; set; }

        public DateTime? Updated_at { get; set; }
        public bool Requested { get; set; }
    }
}