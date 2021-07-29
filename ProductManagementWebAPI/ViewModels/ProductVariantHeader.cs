using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductManagementWebAPI.ViewModels
{
    public class ProductVariantHeader
    {
        public string PRODUCT_NAME { get; set; }
        public string PRODUCT_DESCRIPTION { get; set; }
        public int PRODUCT_TypeID { get; set; }
        public int CategoryID { get; set; }
        public int PRODUCT_ORDER_NUMBER { get; set; }
        public DateTime PRODUCT_CREATE_DATE { get; set; }
        public string PRODUCT_CODE { get; set; }
        public ProductVariants productVariants { get; set; }
    }
}