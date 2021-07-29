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
    public class ColourController : ApiController
    {
        private ProductManagementEntities db = new ProductManagementEntities();

        // GET: api/Colour
        [Route("api/Colour/GetColor")]
        public ColorHeader GetColor()
        {
            ColorHeader header = new ColorHeader();
            try
            {
                var attribute = db.COLOURs.ToList();
                List<Colors> list = new List<Colors>();
                foreach (var item in attribute)
                {
                    Colors color = new Colors();
                    color.ColorId = item.COLOUR_ID;
                    color.ColorName = item.COLOUR_NAME;
                    list.Add(color);

                }
                header.colors = list;
                header.message = "success";
                header.statusCode = "200";
            }
            catch (Exception ex)
            {

                header.message =ex.Message;
                header.statusCode = "401";
            }

            return header;
        }
        [Route("api/Colour/GetColor/{id}")]
        public ColorHeader GetColorById(int id)
        {
            ColorHeader header = new ColorHeader();
            try
            {
                var attribute = db.COLOURs.Where(x=>x.COLOUR_ID == id).ToList();
                List<Colors> list = new List<Colors>();
                foreach (var item in attribute)
                {
                    Colors color = new Colors();
                    color.ColorId = item.COLOUR_ID;
                    color.ColorName = item.COLOUR_NAME;
                    list.Add(color);

                }
                header.colors = list;
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
        [Route("api/Colour/PostColour")]
        public ApiResponse PostColour(Colors color)
        {
            ApiResponse response = new ApiResponse();
            try
            {
                COLOUR cOLOUR = new COLOUR();
                cOLOUR.COLOUR_NAME = color.ColorName;
                db.COLOURs.Add(cOLOUR);
                db.SaveChanges();
                response.message = "Color  with id " + cOLOUR.COLOUR_ID + " successfully created";
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