using System.ComponentModel.DataAnnotations;

namespace Mint.Fun.Models;

public class CollectionModel
{
    [Required]
    public string Name { get; set; }
    [Required]
    public double Price { get; set; }
    [Required]
    public IFormFile CollectionImage { get; set; }
    [Required]
    public int MaxSupply { get; set; }
}