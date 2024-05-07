using shop_giay.Data;

namespace shop_giay.ViewModel
{
    public class SizeVM
    {
        public int? Size1 { get; set; }

    }
    public class SizeMD:SizeVM 
    
    {
        public int IdSize { get; set; }


        public virtual ICollection<ProductSizeQuantity> ProductSizeQuantities { get; set; } = new List<ProductSizeQuantity>();
    }
}

