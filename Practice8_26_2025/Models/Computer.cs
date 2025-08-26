using System.ComponentModel.DataAnnotations;

namespace Practice8_26_2025_Copy.Models
{
    public class Computer
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Brand { get; set; } = string.Empty;
        
        [Required]
        [StringLength(100)]
        public string Model { get; set; } = string.Empty;
        
        [Required]
        [StringLength(50)]
        public string Processor { get; set; } = string.Empty;
        
        [Required]
        [Range(1, 128)]
        public int RamGB { get; set; }
        
        [Required]
        [Range(1, 10000)]
        public int StorageGB { get; set; }
        
        [Required]
        [StringLength(20)]
        public string StorageType { get; set; } = string.Empty; // SSD, HDD, etc.
        
        [Required]
        [StringLength(20)]
        public string OperatingSystem { get; set; } = string.Empty;
        
        [Range(1900, 2030)]
        public int? YearManufactured { get; set; }
        
        [Range(0, 100000)]
        public decimal? PurchasePrice { get; set; }
        
        [StringLength(500)]
        public string? Notes { get; set; }
        
        public DateTime DateAdded { get; set; } = DateTime.Now;
        
        public bool IsActive { get; set; } = true;
    }
} 