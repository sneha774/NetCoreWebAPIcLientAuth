﻿namespace NetCoreWebAPIcLientAuth.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        // Relationships
        public int? StockId { get; set; } // Navigation Property.
        public Stock? Stock { get; set; } 


    }
}