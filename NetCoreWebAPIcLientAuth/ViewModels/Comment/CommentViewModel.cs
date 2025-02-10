namespace NetCoreWebAPIcLientAuth.ViewModels.Comment
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        // Relationships
        public int? StockId { get; set; } // Foreign Key
    }
}
