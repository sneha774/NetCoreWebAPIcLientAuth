using NetCoreWebAPIcLientAuth.DTOs.Stock;
using NetCoreWebAPIcLientAuth.Models;

namespace NetCoreWebAPIcLientAuth.Mappers
{
    public static class StockMappers
    {
        public static StockViewModel ToStockViewModel(this Stock stockModel)
        {
            StockViewModel stockvm = new StockViewModel
            {
                Id = stockModel.Id,
                Symbol = stockModel.Symbol,
                Company = stockModel.Company,
                Industry = stockModel.Industry,
                Purchase = stockModel.Purchase,
                LastDiv = stockModel.LastDiv,
                MarketCap = stockModel.MarketCap,
            };
            return stockvm;
        }
    }
}
