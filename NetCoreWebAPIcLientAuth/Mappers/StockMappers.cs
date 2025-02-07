using NetCoreWebAPIcLientAuth.DTOs.Stock;
using NetCoreWebAPIcLientAuth.Models;
using NetCoreWebAPIcLientAuth.ViewModels.Stock;

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

        public static Stock ToStockFromCreateRequestViewModel(this StockCreateRequestVM stockCreateRequest)
        {
            var stock = new Stock
            {
                Symbol = stockCreateRequest.Symbol,
                Company = stockCreateRequest.Company,
                Industry = stockCreateRequest.Industry,
                Purchase = stockCreateRequest.Purchase,
                LastDiv = stockCreateRequest.LastDiv,
                MarketCap = stockCreateRequest.MarketCap,
            };
            return stock;
        }


    }
}
