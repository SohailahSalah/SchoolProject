using System.ComponentModel.DataAnnotations;

namespace SchoolProject.Helper
{
    public class QueryObject
    {
        public string? SortBy { get; set; } = null;
        public bool IsDescending { get; set; } = false;
        [Range(1, int.MaxValue)]
        public int PageNumber { get; set; } = 1;

        [Range(1, 100)]
        public int PageSize { get; set; } = 20;

    }
}
