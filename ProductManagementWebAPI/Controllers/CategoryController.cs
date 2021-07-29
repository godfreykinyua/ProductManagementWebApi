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
using Newtonsoft.Json;
using ProductManagementWebAPI.Models;
using ProductManagementWebAPI.ViewModels;

namespace ProductManagementWebAPI.Controllers
{
    public class CategoryController : ApiController
    {
        private ProductManagementEntities db = new ProductManagementEntities();

        // GET: api/Category
        //public IQueryable<CATEGORY> GetCATEGORies()
        //{
        //    return db.CATEGORies;
        //}
        public CategoryHeader GetCATEGORies()
        {
            CategoryHeader header = new CategoryHeader();
            try
            {
                var cat = db.CATEGORies.ToList();
                List<Categories> list = new List<Categories>();
                foreach (var item in cat)
                {
                    Categories category = new Categories();
                    category.CATEGORYID = item.CATEGORYID;
                    category.CATEGORY_NAME = item.CATEGORY_NAME;
                    list.Add(category);
                }
                header.CategoryList = list;
                header.message = "success";
                header.statusCode = "200";
            }
            catch (Exception ex)
            {

                header.message = ex.Message;
                header.statusCode = "401";
            }
            // var json = JsonConvert.SerializeObject(list);
            return header ;
        }
        // GET: api/Category/5
        [ResponseType(typeof(CATEGORY))]
        public IHttpActionResult GetCATEGORY(int id)
        {
            CATEGORY cATEGORY = db.CATEGORies.Find(id);
            if (cATEGORY == null)
            {
                return NotFound();
            }

            return Ok(cATEGORY);
        }

        // PUT: api/Category/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCATEGORY(int id, CATEGORY cATEGORY)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cATEGORY.CATEGORYID)
            {
                return BadRequest();
            }

            db.Entry(cATEGORY).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CATEGORYExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }
        // POST: api/Category
        [ResponseType(typeof(CATEGORY))]
        public IHttpActionResult PostCATEGORY(Categories category)
        {
            var json = JsonConvert.SerializeObject(category);
            var model = JsonConvert.DeserializeObject<Categories>(json);
            CATEGORY cat = new CATEGORY();
            cat.CATEGORYID = category.CATEGORYID;
            cat.CATEGORY_NAME = category.CATEGORY_NAME;

            db.CATEGORies.Add(cat);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = category.CATEGORYID }, category);
        }

        //// POST: api/Category
        //[ResponseType(typeof(CATEGORY))]
        //public IHttpActionResult PostCATEGORY(CATEGORY cATEGORY)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.CATEGORies.Add(cATEGORY);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = cATEGORY.CATEGORYID }, cATEGORY);
        //}

        // DELETE: api/Category/5
        [ResponseType(typeof(CATEGORY))]
        public IHttpActionResult DeleteCATEGORY(int id)
        {
            CATEGORY cATEGORY = db.CATEGORies.Find(id);
            if (cATEGORY == null)
            {
                return NotFound();
            }

            db.CATEGORies.Remove(cATEGORY);
            db.SaveChanges();

            return Ok(cATEGORY);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CATEGORYExists(int id)
        {
            return db.CATEGORies.Count(e => e.CATEGORYID == id) > 0;
        }
    }
}