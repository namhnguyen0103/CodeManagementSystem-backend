using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace API.Models;

[PrimaryKey(nameof(Id))]
public class Product
{
    public int Id { get; set; }

    public string Product_name { get; set; } = string.Empty;

    public string Product_description { get; set; } = string.Empty;

    [Column(TypeName = "decimal(10,2)")]
    public decimal Price { get; set; }

    public string? Img { get; set; } = string.Empty;

    public DateTime? Created_at { get; set; }

    public DateTime? Deleted_at { get; set; }

    public DateTime? Updated_at { get; set; }

}
