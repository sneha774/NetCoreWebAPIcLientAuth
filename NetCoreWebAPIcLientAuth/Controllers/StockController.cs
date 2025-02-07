using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetCoreWebAPIcLientAuth.Data;
using NetCoreWebAPIcLientAuth.Interfaces;
using NetCoreWebAPIcLientAuth.Mappers;
using NetCoreWebAPIcLientAuth.ViewModels.Stock;

namespace NetCoreWebAPIcLientAuth.Controllers
{
    [Route("api/stock")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IStockRepository _stockRepo;

        public StockController(ApplicationDbContext context, IStockRepository stockRepo)
        {
            _stockRepo = stockRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var stocks = await _stockRepo.GetAllAsync();
            var stocksViewModel = stocks.Select(s => s.ToStockViewModel());
            return Ok(stocksViewModel);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute]int id)
        {
            var stock = await _stockRepo.GetByIdAsync(id);
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
            await _stockRepo.CreateAsync(stock);
            return CreatedAtAction(nameof(GetById), new { id = stock.Id }, stock.ToStockViewModel());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] StockUpdateRequestVM stockUpdateRequest)
        {
            var stock  = await _stockRepo.UpdateAsync(id, stockUpdateRequest);
            if (stock == null)
            {
                return NotFound();
            }

            return Ok(stock.ToStockViewModel());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var stock = await _stockRepo.DeleteAsync(id);
            if(stock == null)
            {
                return NotFound();
            }
            
            return NoContent();  // No Error is a good news
        }
    }
}
