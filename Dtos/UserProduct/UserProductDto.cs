using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos.UserProduct
{
    public class UserProductDto
    {
        public int Id { get; set; }

        public int Product_id { get; set; }

        public DateTime ExpirationDate { get; set; }

        public int Mid { get; set; }

        public int Sitecode { get; set; }

        public string ActivationCode { get; set; } = string.Empty;
        public bool Requested { get; set; }
    }
}