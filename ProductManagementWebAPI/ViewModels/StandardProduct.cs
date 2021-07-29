using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductManagementWebAPI.ViewModels
{
    public class StandardProduct
    {
        public string PRODUCT_NAME { get; set; }
        public string PRODUCT_DESCRIPTION { get; set; }
        public double PRODUCT_COST { get; set; }
        public double PRODUCT_PRICE { get; set; }
        public int PRODUCT_TypeID { get; set; }
        public int CategoryID { get; set; }
        public int PRODUCT_ORDER_NUMBER { get; set; }
        public DateTime PRODUCT_CREATE_DATE { get; set; }
        public string PRODUCT_CODE { get; set; }
        public int PRODUCT_QTY { get; set; }
        public int Status { get; set; }
    }
}