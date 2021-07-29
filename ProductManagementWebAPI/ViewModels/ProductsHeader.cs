using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductManagementWebAPI.ViewModels
{
    public class ProductsHeader
    {
        public string message { get; set; }
        public string statusCode { get; set; }
        public List<Products> ProductsList { get; set; }
    }
}