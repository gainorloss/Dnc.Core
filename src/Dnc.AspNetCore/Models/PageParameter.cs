namespace Dnc.AspNetCore.Models
{
    public class PageParameter
    {
        private PageParameter()
        { }
        public PageParameter(int page, int size)
        {
            PageIndex = page;
            PageSize = size;
        }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}