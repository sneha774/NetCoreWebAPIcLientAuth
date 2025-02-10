using NetCoreWebAPIcLientAuth.Models;
using NetCoreWebAPIcLientAuth.ViewModels.Comment;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCoreWebAPIcLientAuth.DTOs.Stock
{
    public class StockViewModel
    {
        public int Id { get; set; }
        public string Symbol { get; set; } = string.Empty;
        public string Company { get; set; } = string.Empty;
        public string Industry { get; set; } = string.Empty;

        public decimal Purchase { get; set; }

        public decimal LastDiv { get; set; }

        public long MarketCap { get; set; }
        public List<CommentViewModel> Comments { get; set; } = new List<CommentViewModel>();
    }
}
