namespace NetCoreWebAPIcLientAuth.ViewModels.Stock
{
    public class StockUpdateRequestVM
    {
        public string Symbol { get; set; } = string.Empty;
        public string Company { get; set; } = string.Empty;
        public string Industry { get; set; } = string.Empty;

        public decimal Purchase { get; set; }

        public decimal LastDiv { get; set; }

        public long MarketCap { get; set; }
    }
}
