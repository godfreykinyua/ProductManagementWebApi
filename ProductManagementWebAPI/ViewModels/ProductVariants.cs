using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductManagementWebAPI.ViewModels
{
    public class ProductVariants
    {
        public int ProductVariantID { get; set; }
        public int ProductId { get; set; }
        public double ProductPrice { get; set; }
        public double ProductCost { get; set; }
        public int ColourId { get; set; }
        public int SizeId { get; set; }
        public int ProductQty { get; set; }
        public string SKU { get; set; }
    }
}