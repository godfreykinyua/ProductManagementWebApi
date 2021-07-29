using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductManagementWebAPI.ViewModels
{
    public class Products
    {
        //product properties
        public int PRODUCT_ID { get; set; }
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
        //product variant properties
        public double ProductPrice { get; set; }
        public int ProductQty { get; set; }
        public string SKU { get; set; }
        public double ProductCost { get; set; }
        public int ColourId { get; set; }
        public int SizeId { get; set; }
        public string ColourName { get; set; }
        public string SizeName { get; set; }
        
    }
}