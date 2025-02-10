using NetCoreWebAPIcLientAuth.Models;
using NetCoreWebAPIcLientAuth.ViewModels.Comment;
using System.Runtime.CompilerServices;

namespace NetCoreWebAPIcLientAuth.Mappers
{
    public static class CommentMappers
    {
        public static CommentViewModel ToCommentVM(this Comment commentModel)
        {
            return new CommentViewModel
            {
                Id = commentModel.Id,
                Title = commentModel.Title,
                Content = commentModel.Content,
                CreatedOn = commentModel.CreatedOn,
                StockId = commentModel.StockId,
            };
        }

        public static Comment ToCommentFromCreateVM(this CommentCreateRequestVM commentCreateRequest, int stockId)
        {
            return new Comment
            {
                Title = commentCreateRequest.Title,
                Content = commentCreateRequest.Content,
                StockId = stockId,
            };
        }

        public static Comment ToCommentFromUpdateVM(this CommentUpdateRequestVM commentUpdateRequest)
        {
            return new Comment
            {
                Title = commentUpdateRequest.Title,
                Content = commentUpdateRequest.Content,
            };
        }
    }
}
