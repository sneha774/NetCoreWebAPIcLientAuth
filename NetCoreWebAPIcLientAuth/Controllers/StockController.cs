using Microsoft.AspNetCore.Mvc;
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
        public IActionResult GetAll()
        {
            var stocks = _context.Stocks.ToList()                                       // ToList is the defered execution
                .Select(s => s.ToStockViewModel());
            return Ok(stocks);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute]int id)
        {
            var stock = _context.Stocks.Find(id);
            if(stock == null)
            {
                return NotFound();
            }
            return Ok(stock.ToStockViewModel());
        }

        [HttpPost]
        public IActionResult Create([FromBody] StockCreateRequestVM stockCreateRequest)
        {
            var stock = stockCreateRequest.ToStockFromCreateRequestViewModel();
            _context.Stocks.Add(stock);                                                 // Starts tracking the entitiy to be saved
            _context.SaveChanges();                                                     // Saves the tracked changes in the database
            return CreatedAtAction(nameof(GetById), new { id = stock.Id }, stock);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] StockUpdateRequestVM stockUpdateRequest)
        {
            var stock  = _context.Stocks.FirstOrDefault(s => s.Id == id);               // EF retrieves the object and starts tracking it
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

            _context.SaveChanges();

            return Ok(stock.ToStockViewModel());
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var stock = _context.Stocks.FirstOrDefault(s => s.Id == id);
            if(stock == null)
            {
                return NotFound();
            }

            _context.Stocks.Remove(stock);
            _context.SaveChanges();
            
            return NoContent();                                                     // No Error is a good news
        }
    }
}
