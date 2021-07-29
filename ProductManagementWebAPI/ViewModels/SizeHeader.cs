using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductManagementWebAPI.ViewModels
{
    public class SizeHeader
    {
        public string message { get; set; }
        public string statusCode { get; set; }
        public List<Sizes> sizes { get; set; }
    }
}