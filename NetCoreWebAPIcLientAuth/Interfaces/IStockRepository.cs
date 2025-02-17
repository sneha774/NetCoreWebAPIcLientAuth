﻿using NetCoreWebAPIcLientAuth.Helpers;
using NetCoreWebAPIcLientAuth.Models;
using NetCoreWebAPIcLientAuth.ViewModels.Stock;

namespace NetCoreWebAPIcLientAuth.Interfaces
{
    public interface IStockRepository
    {
        Task<List<Stock>> GetAllAsync(QueryObject queryObject);

        Task<Stock?> GetByIdAsync(int id);

        Task<Stock> CreateAsync(Stock stock);

        Task<Stock?> UpdateAsync(int id, StockUpdateRequestVM stockUpdateModel);

        Task<Stock?> DeleteAsync(int id);

        Task<bool> StockExists(int id);
    }
}
