using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetCoreWebAPIcLientAuth.Data;
using NetCoreWebAPIcLientAuth.Mappers;
using NetCoreWebAPIcLientAuth.ViewModels.Stock;

namespace NetCoreWebAPIcLientAuth.Controllers
{
    [Route("api/stock")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StockController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var stocksModel = await _context.Stocks.ToListAsync(); // ToList is the defered execution
            var stocks = stocksModel.Select(s => s.ToStockViewModel());
            return Ok(stocks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute]int id)
        {
            var stock = await _context.Stocks.FindAsync(id);
            if(stock == null)
            {
                return NotFound();
            }
            return Ok(stock.ToStockViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] StockCreateRequestVM stockCreateRequest)
        {
            var stock = stockCreateRequest.ToStockFromCreateRequestViewModel();
            await _context.Stocks.AddAsync(stock);                                                 // Starts tracking the entitiy to be saved
            await _context.SaveChangesAsync();                                                     // Saves the tracked changes in the database
            return CreatedAtAction(nameof(GetById), new { id = stock.Id }, stock);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] StockUpdateRequestVM stockUpdateRequest)
        {
            var stock  = await _context.Stocks.FirstOrDefaultAsync(s => s.Id == id);               // EF retrieves the object and starts tracking it
            if (stock == null)
            {
                return NotFound();
            }

            stock.Symbol = stockUpdateRequest.Symbol;                                   // Hence, we have to update the same object.
            stock.Company = stockUpdateRequest.Company;
            stock.Industry = stockUpdateRequest.Industry;
            stock.Purchase = stockUpdateRequest.Purchase;
            stock.LastDiv = stockUpdateRequest.LastDiv;
            stock.MarketCap = stockUpdateRequest.MarketCap;

            await _context.SaveChangesAsync();

            return Ok(stock.ToStockViewModel());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var stock = await _context.Stocks.FirstOrDefaultAsync(s => s.Id == id);
            if(stock == null)
            {
                return NotFound();
            }

            _context.Stocks.Remove(stock);
            await _context.SaveChangesAsync();
            
            return NoContent();                                                     // No Error is a good news
        }
    }
}
