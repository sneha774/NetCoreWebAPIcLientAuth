using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using NetCoreWebAPIcLientAuth.Data;
using NetCoreWebAPIcLientAuth.Helpers;
using NetCoreWebAPIcLientAuth.Interfaces;
using NetCoreWebAPIcLientAuth.Models;
using NetCoreWebAPIcLientAuth.ViewModels.Stock;

namespace NetCoreWebAPIcLientAuth.Repository
{
    public class StockRepository : IStockRepository
    {
        private readonly ApplicationDbContext _context;

        public StockRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Stock>> GetAllAsync(QueryObject query)
        {
            var stocks =  _context.Stocks.Include(s => s.Comments).AsQueryable(); // AsQueryable allows to add more queries before the sql is actually executed

            if(!string.IsNullOrWhiteSpace(query.Symbol))
            {
                stocks = stocks.Where(s => s.Symbol.Contains(query.Symbol));
            }

            if (!string.IsNullOrWhiteSpace(query.Company))
            {
                stocks = stocks.Where(s => s.Company.Contains(query.Company));
            }

            if (!string.IsNullOrWhiteSpace(query.Industry))
            {
                stocks = stocks.Where(s => s.Industry.Contains(query.Industry));
            }

            return await stocks.ToListAsync(); // ToList is the defered execution. This is when the SQL query is actually run.
        }

        public async Task<Stock?> GetByIdAsync(int id)
        {
            return await _context.Stocks.Include(s => s.Comments).FirstOrDefaultAsync(s => s.Id == id);
        }
        public async Task<Stock> CreateAsync(Stock stock)
        {
            await _context.Stocks.AddAsync(stock);  // Starts tracking the entitiy to be saved
            await _context.SaveChangesAsync();      // Saves the tracked changes in the database
            return stock;
        }

        public async Task<Stock?> UpdateAsync(int id, StockUpdateRequestVM stockUpdateRequest)
        {
            var stock = await _context.Stocks.FirstOrDefaultAsync(s => s.Id == id); // EF retrieves the object and starts tracking it
            if (stock == null)
            {
                return null;
            }
            stock.Symbol = stockUpdateRequest.Symbol; // Hence, we have to update the same object.
            stock.Company = stockUpdateRequest.Company;
            stock.Industry = stockUpdateRequest.Industry;
            stock.Purchase = stockUpdateRequest.Purchase;
            stock.LastDiv = stockUpdateRequest.LastDiv;
            stock.MarketCap = stockUpdateRequest.MarketCap;

            await _context.SaveChangesAsync();

            return stock;
        }

        public async Task<Stock?> DeleteAsync(int id)
        {
            var stock = await _context.Stocks.FirstOrDefaultAsync(s => s.Id == id);
            if (stock == null)
            {
                return null;
            }

            _context.Stocks.Remove(stock);
            await _context.SaveChangesAsync();

            return stock;
        }

        public Task<bool> StockExists(int id)
        {
            return _context.Stocks.AnyAsync(s => s.Id == id);
        }
    }
}
