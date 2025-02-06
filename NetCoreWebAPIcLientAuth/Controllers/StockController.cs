using Microsoft.AspNetCore.Mvc;
using NetCoreWebAPIcLientAuth.Data;
using NetCoreWebAPIcLientAuth.Mappers;

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
        public ActionResult GetAll()
        {
            var stocks = _context.Stocks.ToList() // ToList is the defered execution
                .Select(s => s.ToStockViewModel());
            return Ok(stocks);
        }

        [HttpGet("{id}")]
        public ActionResult GetById([FromRoute]int id)
        {
            var stock = _context.Stocks.Find(id);
            if(stock == null)
            {
                return NotFound();
            }
            return Ok(stock.ToStockViewModel());
        }
    }
}
