using System.ComponentModel.DataAnnotations;

namespace NetCoreWebAPIcLientAuth.ViewModels.Stock
{
    public class StockCreateRequestVM
    {
        [Required]
        [MaxLength(10, ErrorMessage = "Symbol cannot be over 10 characters")]
        public string Symbol { get; set; } = string.Empty;

        [Required]
        [MaxLength(100, ErrorMessage = "Company cannot be over 100 characters")]
        public string Company { get; set; } = string.Empty;
        
        [Required]
        [MaxLength(100, ErrorMessage = "Industry cannot be over 100 characters")]
        public string Industry { get; set; } = string.Empty;

        [Required]
        [Range(1,1000000000)]
        public decimal Purchase { get; set; }

        [Range(0.001, 100)]
        public decimal LastDiv { get; set; }

        [Range(1, 5000000000)]
        public long MarketCap { get; set; }
    }
}
