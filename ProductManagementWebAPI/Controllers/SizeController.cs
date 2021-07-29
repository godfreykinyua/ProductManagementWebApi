using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ProductManagementWebAPI.Models;
using ProductManagementWebAPI.ViewModels;

namespace ProductManagementWebAPI.Controllers
{
    public class SizeController : ApiController
    {
        private ProductManagementEntities db = new ProductManagementEntities();

        // GET: api/Size
        [Route("api/Size/GetSizes")]
        public SizeHeader GetSizes()
        {
            SizeHeader header = new SizeHeader();
            List<Sizes> list = new List<Sizes>();
            try
            {
                var size = db.SIZEs.ToList();
                foreach (var item in size)
                {
                    Sizes sizes = new Sizes();
                    sizes.SizeId = item.SIZE_ID;
                    sizes.SizeName = item.SIZE_NAME;
                    list.Add(sizes);
                }
                header.sizes = list;
                header.message = "success";
                header.statusCode = "200";
            }
            catch (Exception ex)
            {
                header.message = ex.Message;
                header.statusCode = "401";
            }

            return header;
        }
        [Route("api/Size/GetSizes/{id}")]
        public SizeHeader GetSizes(int id)
        {
            SizeHeader header = new SizeHeader();
            List<Sizes> list = new List<Sizes>();
            try
            {
                var size = db.SIZEs.Where(x=>x.SIZE_ID== id).ToList();
                foreach (var item in size)
                {
                    Sizes sizes = new Sizes();
                    sizes.SizeId = item.SIZE_ID;
                    sizes.SizeName = item.SIZE_NAME;
                    list.Add(sizes);
                }
                header.sizes = list;
                header.message = "success";
                header.statusCode = "200";
            }
            catch (Exception ex)
            {
                header.message = ex.Message;
                header.statusCode = "401";
            }

            return header;
        }
        


        public ApiResponse PostSize(Sizes model)
        {
            ApiResponse response = new ApiResponse();
            try
            {
                SIZE size = new SIZE();
                size.SIZE_NAME = model.SizeName;
                db.SIZEs.Add(size);
                db.SaveChanges();
                response.message = "Size  with id " + size.SIZE_ID + " successfully created";
                response.statusCode = "200";
            }
            catch (Exception ex)
            {

                response.message = ex.Message;
                response.statusCode = "401";
            }


            return response;
        }

    }
}