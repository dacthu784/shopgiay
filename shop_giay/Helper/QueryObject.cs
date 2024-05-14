using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace shop_giay.Helper
{
    public class QueryObject
    {
        public bool IsDecsending { get; set; } = false;
        public int PageNumber { get; set; } = 1;
        //[BindNever]
        public int PageSize { get; set; } = 20;
    }
}
