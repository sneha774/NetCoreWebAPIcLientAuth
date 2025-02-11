namespace NetCoreWebAPIcLientAuth.Helpers
{
    public class QueryObject
    {
        public string? Symbol { get; set; } = null;
        public string? Company { get; set; } = null;
        public string? Industry { get; set; } = null;
        public string? SortBy { get; set; } = null;
        public bool IsDescending { get; set; } = false;
    }
}
