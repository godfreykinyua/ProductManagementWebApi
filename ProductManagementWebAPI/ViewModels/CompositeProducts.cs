using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductManagementWebAPI.ViewModels
{
    public class CompositeProducts
    {
        public int CompositeId { get; set; }
        public int MainProductId { get; set; }
        public int CompositeProductId { get; set; }
        public double ExtraPrice { get; set; }
        public bool Mandatory { get; set; }
        public bool Costed { get; set; }
    }
}