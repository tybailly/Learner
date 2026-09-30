using System.ComponentModel.DataAnnotations;

namespace AssetPortal.Models;

public class Asset
{
    public int Id { get; set; }

    [Required]
    [StringLength(2)]
    public string AssetTag { get; set; } = "";

    [Required]
    [StringLength(10)]
    public string AssetName { get; set; } = "";

    [Required]
    [StringLength(10)]
    public string Owner { get; set; } = "";

    public DateTime PurchaseDate { get; set; }
}