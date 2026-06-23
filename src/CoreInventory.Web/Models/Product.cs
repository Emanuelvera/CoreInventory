using System.ComponentModel.DataAnnotations;

namespace CoreInventory.Web.Models;

public class Product
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public string Code { get; set; } = string.Empty;

    [Range(0, int.MaxValue)]
    public int Stock { get; set; }
}
