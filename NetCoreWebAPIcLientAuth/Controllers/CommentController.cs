using Microsoft.AspNetCore.Mvc;
using NetCoreWebAPIcLientAuth.Interfaces;
using NetCoreWebAPIcLientAuth.Mappers;
using NetCoreWebAPIcLientAuth.ViewModels.Comment;

namespace NetCoreWebAPIcLientAuth.Controllers
{
    [Route("api/comment")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepo;
        private readonly IStockRepository _stockRepo;

        public CommentController(ICommentRepository commentRepo, IStockRepository stockRepo)
        {
            _commentRepo = commentRepo;
            _stockRepo = stockRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() 
        { 
            var comments = await _commentRepo.GetAllAsync();
            var commentsVM = comments.Select(c => c.ToCommentVM());
            return Ok(commentsVM);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var comment = await _commentRepo.GetByIdAsync(id);
            if(comment == null)
            {
                return NotFound();
            }
            return Ok(comment.ToCommentVM());
        }

        [HttpPost]
        [Route("{stockId}")]
        public async Task<IActionResult> Create([FromRoute] int stockId, [FromBody] CommentCreateRequestVM createCommentRequest)
        {
            if(!await _stockRepo.StockExists(stockId))
            {
                return BadRequest($"Stock with id {stockId} does not exist");
            }
            var comment = createCommentRequest.ToCommentFromCreateVM(stockId);
            await _commentRepo.CreateAsync(comment);
            return CreatedAtAction(nameof(GetById), new { id = comment.Id }, comment);

        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] CommentUpdateRequestVM updateCommentRequest)
        {
            var comment = await _commentRepo.UpdateAsync(id, updateCommentRequest.ToCommentFromUpdateVM());
            if(comment == null)
            {  
                return NotFound();
            }

            return Ok(comment.ToCommentVM());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var comment = await _commentRepo.DeleteAsync(id);
            if(comment == null) 
            {
                return NotFound("Comment does not exist");
            }
            return NoContent();
        }
    }
}
