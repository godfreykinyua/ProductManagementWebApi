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
    public class ProductController : ApiController
    {
        private ProductManagementEntities db = new ProductManagementEntities();

        // GET: api/Product
        //public IQueryable<PRODUCT> GetPRODUCTs()
        //{
        //    return db.PRODUCTs;
        //}

        [Route("api/Product/GetProducts")]
        public ProductsHeader GetPRODUCTs()
        {

            ProductsHeader header = new ProductsHeader();
            try
            {
                List<Products> list = new List<Products>();
                var products = from x in db.PRODUCTs
                               join y in db.ProductVariants on x.PRODUCT_ID equals y.ProductId
                               join z in db.COLOURs on y.ColourId equals z.COLOUR_ID
                               join k in db.SIZEs on y.SizeId equals k.SIZE_ID
                               
                               select new Products
                               {
                                   PRODUCT_ID = x.PRODUCT_ID,
                                   PRODUCT_NAME = x.PRODUCT_NAME,
                                   PRODUCT_DESCRIPTION = x.PRODUCT_DESCRIPTION,
                                   PRODUCT_PRICE = (double)x.PRODUCT_PRICE,
                                   PRODUCT_COST = (double)x.PRODUCT_COST,
                                   PRODUCT_QTY = (int)x.PRODUCT_QTY,
                                   PRODUCT_TypeID = (int)x.PRODUCT_TypeID,
                                   CategoryID = (int)x.CategoryID,
                                   ProductPrice = (double)y.ProductPrice,
                                   ProductCost = (double)y.ProductCost,
                                   ColourName = z.COLOUR_NAME,
                                   SizeName = k.SIZE_NAME,
                                   ProductQty = (int)y.ProductQty,
                                   ColourId = z.COLOUR_ID,
                                   SizeId = k.SIZE_ID,
                                   SKU = y.SKU,
                                   PRODUCT_CREATE_DATE = (DateTime)x.PRODUCT_CREATE_DATE



                               };

                foreach (var item in products)
                {
                    Products product = new Products();
                    product.PRODUCT_ID = item.PRODUCT_ID;
                    product.PRODUCT_NAME = item.PRODUCT_NAME;
                    product.PRODUCT_DESCRIPTION = item.PRODUCT_DESCRIPTION;
                    product.CategoryID = item.CategoryID;
                    product.PRODUCT_TypeID = item.PRODUCT_TypeID;
                    if (item.PRODUCT_TypeID == 2)
                    {
                        product.PRODUCT_QTY = item.ProductQty;
                        product.ProductPrice = item.ProductPrice;
                        product.ProductCost = item.ProductCost;
                        product.ColourName = item.ColourName;
                        product.SizeName = item.SizeName;
                        product.SizeId = item.SizeId;
                        product.ColourId = item.ColourId;
                        product.SKU = item.SKU;
                        product.PRODUCT_CREATE_DATE = item.PRODUCT_CREATE_DATE;
                    }
                    else
                    {
                        product.PRODUCT_PRICE = item.PRODUCT_PRICE;
                        product.PRODUCT_COST = item.PRODUCT_COST;
                        product.PRODUCT_QTY = item.PRODUCT_QTY;
                    }

                    list.Add(product);
                    
                }
                header.ProductsList = list;
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
        [Route("api/Product/GetProductsByCategoryId/{categoryId}")]
        [ResponseType(typeof(PRODUCT))]
        public ProductsHeader GetProductsByCategoryId(int categoryId)
        {

            ProductsHeader header = new ProductsHeader();
            try
            {
                List<Products> list = new List<Products>();
                var products = from x in db.PRODUCTs
                               join y in db.ProductVariants on x.PRODUCT_ID equals y.ProductId
                               join z in db.COLOURs on y.ColourId equals z.COLOUR_ID
                               join k in db.SIZEs on y.SizeId equals k.SIZE_ID
                               where x.CategoryID == categoryId
                               select new Products
                               {
                                   PRODUCT_ID = x.PRODUCT_ID,
                                   PRODUCT_NAME = x.PRODUCT_NAME,
                                   PRODUCT_DESCRIPTION = x.PRODUCT_DESCRIPTION,
                                   PRODUCT_PRICE = (double)x.PRODUCT_PRICE,
                                   PRODUCT_COST = (double)x.PRODUCT_COST,
                                   PRODUCT_QTY = (int)x.PRODUCT_QTY,
                                   PRODUCT_TypeID = (int)x.PRODUCT_TypeID,
                                   CategoryID = (int)x.CategoryID,
                                   ProductPrice = (double)y.ProductPrice,
                                   ProductCost = (double)y.ProductCost,
                                   ColourName = z.COLOUR_NAME,
                                   SizeName = k.SIZE_NAME,
                                   ProductQty = (int)y.ProductQty,
                                   ColourId = z.COLOUR_ID,
                                   SizeId = k.SIZE_ID,
                                   SKU = y.SKU,
                                   PRODUCT_CREATE_DATE = (DateTime)x.PRODUCT_CREATE_DATE



                               };

                foreach (var item in products)
                {
                    Products product = new Products();
                    product.PRODUCT_ID = item.PRODUCT_ID;
                    product.PRODUCT_NAME = item.PRODUCT_NAME;
                    product.PRODUCT_DESCRIPTION = item.PRODUCT_DESCRIPTION;
                    product.CategoryID = item.CategoryID;
                    product.PRODUCT_TypeID = item.PRODUCT_TypeID;
                    if (item.PRODUCT_TypeID == 2)
                    {
                        product.PRODUCT_QTY = item.ProductQty;
                        product.ProductPrice = item.ProductPrice;
                        product.ProductCost = item.ProductCost;
                        product.ColourName = item.ColourName;
                        product.SizeName = item.SizeName;
                        product.SizeId = item.SizeId;
                        product.ColourId = item.ColourId;
                        product.SKU = item.SKU;
                        product.PRODUCT_CREATE_DATE = item.PRODUCT_CREATE_DATE;
                    }
                    else
                    {
                        product.PRODUCT_PRICE = item.PRODUCT_PRICE;
                        product.PRODUCT_COST = item.PRODUCT_COST;
                        product.PRODUCT_QTY = item.PRODUCT_QTY;
                    }

                    list.Add(product);
                    
                }
                header.ProductsList = list;
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

        // POST: api/Product
        [Route("api/Product/PostStandardProduct")]
        public ApiResponse PostStandardProduct(StandardProductHeader header)
        {

            var json = JsonConvert.SerializeObject(header);
            var model = JsonConvert.DeserializeObject<StandardProductHeader>(json);
                                  StandardProduct product = model.standardProduct;
                                   PRODUCT pdt = new PRODUCT();
                                   pdt.PRODUCT_NAME = product.PRODUCT_NAME;
                                   pdt.PRODUCT_DESCRIPTION = product.PRODUCT_DESCRIPTION;
                                   pdt.PRODUCT_PRICE = product.PRODUCT_PRICE;
                                   pdt.PRODUCT_COST = product.PRODUCT_COST;
                                   pdt.PRODUCT_QTY = product.PRODUCT_QTY;
                                   pdt.PRODUCT_TypeID = product.PRODUCT_TypeID;
                                   pdt.CategoryID = product.CategoryID;
                                   pdt.PRODUCT_CREATE_DATE = DateTime.Now;
                                   pdt.Status = 1;


            ApiResponse response = new ApiResponse();
            try
            {
                db.PRODUCTs.Add(pdt);
                db.SaveChanges();
                
                response.message = "Standard product with id " +pdt.PRODUCT_ID+ " successfully created";
                response.statusCode = "200";
            }
            catch (Exception ex)
            {

                throw;
            }
           

            return response;
        }
        [Route("api/Product/PostProductWithVariants")]
        public ApiResponse PostProductWithVariants(ProductVariantHeader header)
        {
            ApiResponse response = new ApiResponse();
            try
            {
                var json = JsonConvert.SerializeObject(header);
                var model = JsonConvert.DeserializeObject<ProductVariantHeader>(json);
                ProductVariants variants = header.productVariants;
                PRODUCT prod = new PRODUCT();
                prod.PRODUCT_NAME = header.PRODUCT_NAME;
                prod.PRODUCT_DESCRIPTION = header.PRODUCT_DESCRIPTION;
                prod.PRODUCT_CODE = header.PRODUCT_CODE;
                prod.PRODUCT_ORDER_NUMBER = header.PRODUCT_ORDER_NUMBER;
                prod.PRODUCT_CREATE_DATE = header.PRODUCT_CREATE_DATE;
                prod.PRODUCT_TypeID = header.PRODUCT_TypeID;
                prod.CategoryID = header.CategoryID;
                prod.Status = 1;

                db.PRODUCTs.Add(prod);
                db.SaveChanges();
                ProductVariant productVariant = new ProductVariant();
                productVariant.ProductId = prod.PRODUCT_ID;
                productVariant.ProductPrice = variants.ProductPrice;
                productVariant.ProductCost = variants.ProductCost;
                productVariant.ProductQty = variants.ProductQty;
                productVariant.SizeId = variants.SizeId;
                productVariant.ColourId = variants.ColourId;
                productVariant.SKU = variants.SKU;
                db.ProductVariants.Add(productVariant);
                db.SaveChanges();


                response.message = "Product  with id " + prod.PRODUCT_ID + " successfully created";
                response.statusCode = "200";
            }
            catch (Exception ex)
            {

                response.message = ex.Message;
                response.statusCode = "401";
            }
            return response;
        }

        [Route("api/Product/PostCompositeProducts")]
        public ApiResponse PostCompositeProducts(CompositeProductHeader header)
        {
            ApiResponse response = new ApiResponse();
            try
            {
                var json = JsonConvert.SerializeObject(header);
                var model = JsonConvert.DeserializeObject<CompositeProductHeader>(json);
                CompositeProducts variants = header.compositeProducts;
                PRODUCT prod = new PRODUCT();
                prod.PRODUCT_NAME = header.PRODUCT_NAME;
                prod.PRODUCT_DESCRIPTION = header.PRODUCT_DESCRIPTION;
                prod.PRODUCT_PRICE = header.PRODUCT_PRICE;
                prod.PRODUCT_COST = header.PRODUCT_COST;
                prod.PRODUCT_QTY = header.PRODUCT_QTY;
                prod.PRODUCT_CODE = header.PRODUCT_CODE;
                prod.PRODUCT_ORDER_NUMBER = header.PRODUCT_ORDER_NUMBER;
                prod.PRODUCT_CREATE_DATE = header.PRODUCT_CREATE_DATE;
                prod.PRODUCT_TypeID = header.PRODUCT_TypeID;
                prod.CategoryID = header.CategoryID;
                prod.Status = 1;

                db.PRODUCTs.Add(prod);
                db.SaveChanges();
                CompositeProduct composite = new CompositeProduct();
                composite.CompositeProductId = variants.CompositeProductId;
                composite.MainProductId = prod.PRODUCT_ID;
                composite.Costed = variants.Costed;
                composite.Mandatory = variants.Mandatory;
                composite.ExtraPrice = variants.ExtraPrice;
                db.CompositeProducts.Add(composite);
                db.SaveChanges();


                response.message = "Product  with id " + prod.PRODUCT_ID + " successfully created";
                response.statusCode = "200";
            }
            catch (Exception ex)
            {

                response.message = ex.Message;
                response.statusCode = "401";
            }
            return response;
        }
        [Route("api/Product/UpdateStandardProduct/{id}")]
        public ApiResponse UpdateStandardProduct(int id, StandardProductHeader header)
        {
            ApiResponse response = new ApiResponse();
            var json = JsonConvert.SerializeObject(header);
            var model = JsonConvert.DeserializeObject<StandardProductHeader>(json);
            StandardProduct product = model.standardProduct;
            

            PRODUCT prod = db.PRODUCTs.Find(id);
            if(prod != null)
            {
                prod.PRODUCT_NAME = product.PRODUCT_NAME;
                prod.PRODUCT_DESCRIPTION = product.PRODUCT_DESCRIPTION;
                prod.PRODUCT_PRICE = product.PRODUCT_PRICE;
                prod.PRODUCT_COST = product.PRODUCT_COST;
                prod.PRODUCT_QTY = product.PRODUCT_QTY;
                prod.PRODUCT_TypeID = product.PRODUCT_TypeID;
                prod.CategoryID = product.CategoryID;
                prod.Status = 1;
                db.Entry(prod).State = EntityState.Modified;
                db.SaveChanges();
                response.message = "Standard product with id " + prod.PRODUCT_ID + " successfully updated";
                response.statusCode = "200";
            }
            else
            {
                response.message = "Standard product with id " + prod.PRODUCT_ID + " does not exist";
                response.statusCode = "400";
                return response;

            }
            

            return response;
        }
        
        [Route("api/Product/UpdateProductWithVariants/{id}")]
        public ApiResponse UpdateProductWithVariants(int id,ProductVariantHeader header)
        {
            ApiResponse response = new ApiResponse();
            try
            {
                var json = JsonConvert.SerializeObject(header);
                var model = JsonConvert.DeserializeObject<ProductVariantHeader>(json);
                ProductVariants variants = header.productVariants;

                PRODUCT prod = db.PRODUCTs.Find(id);
                if(prod != null)
                {
                    prod.PRODUCT_NAME = header.PRODUCT_NAME;
                    prod.PRODUCT_DESCRIPTION = header.PRODUCT_DESCRIPTION;
                    prod.PRODUCT_CODE = header.PRODUCT_CODE;
                    prod.PRODUCT_ORDER_NUMBER = header.PRODUCT_ORDER_NUMBER;
                    prod.PRODUCT_CREATE_DATE = header.PRODUCT_CREATE_DATE;
                    prod.PRODUCT_TypeID = header.PRODUCT_TypeID;
                    prod.CategoryID = header.CategoryID;
                    prod.Status = 1;

                    db.Entry(prod).State = EntityState.Modified;
                    db.SaveChanges();

                    // updating productVariant table
                    int pid = variants.ProductVariantID;
                    ProductVariant productVariant = db.ProductVariants.Find(pid);
                    if(productVariant != null)
                    {
                        productVariant.ProductId = prod.PRODUCT_ID;
                        productVariant.ProductPrice = variants.ProductPrice;
                        productVariant.ProductCost = variants.ProductCost;
                        productVariant.ProductQty = variants.ProductQty;
                        productVariant.SizeId = variants.SizeId;
                        productVariant.ColourId = variants.ColourId;
                        productVariant.SKU = variants.SKU;
                        db.Entry(productVariant).State = EntityState.Modified;
                        db.SaveChanges();

                    }
                    else
                    {
                        response.message = "Product Variant  with id " + variants.ProductVariantID + " does not exist";
                        response.statusCode = "200";
                        return response;
                    }


                    response.message = "Product   with id " + id + " successfully updated";
                    response.statusCode = "200";

                }
                
                
            }
            catch (Exception ex)
            {

                response.message = ex.Message;
                response.statusCode = "401";
            }
            return response;
        }

        [Route("api/Product/UpdateCompositeProducts/{id}")]
        public ApiResponse UpdateCompositeProducts(int id, CompositeProductHeader header)
        {
            ApiResponse response = new ApiResponse();
            try
            {
                var json = JsonConvert.SerializeObject(header);
                var model = JsonConvert.DeserializeObject<CompositeProductHeader>(json);
                CompositeProducts variants = header.compositeProducts;
                //updating main product
                PRODUCT prod = db.PRODUCTs.Find(id);
                if(prod != null)
                {
                    prod.PRODUCT_NAME = header.PRODUCT_NAME;
                    prod.PRODUCT_DESCRIPTION = header.PRODUCT_DESCRIPTION;
                    prod.PRODUCT_PRICE = header.PRODUCT_PRICE;
                    prod.PRODUCT_COST = header.PRODUCT_COST;
                    prod.PRODUCT_QTY = header.PRODUCT_QTY;
                    prod.PRODUCT_CODE = header.PRODUCT_CODE;
                    prod.PRODUCT_ORDER_NUMBER = header.PRODUCT_ORDER_NUMBER;
                    prod.PRODUCT_CREATE_DATE = header.PRODUCT_CREATE_DATE;
                    prod.PRODUCT_TypeID = header.PRODUCT_TypeID;
                    prod.CategoryID = header.CategoryID;
                    prod.Status = 1;

                    db.Entry(prod).State = EntityState.Modified;
                    db.SaveChanges();
                    //updating composite table
                    var cId = variants.CompositeId;
                    CompositeProduct composite = db.CompositeProducts.Find(cId);
                    if(composite != null)
                    {
                        composite.CompositeProductId = variants.CompositeProductId;
                        composite.MainProductId = prod.PRODUCT_ID;
                        composite.Costed = variants.Costed;
                        composite.Mandatory = variants.Mandatory;
                        composite.ExtraPrice = variants.ExtraPrice;
                        db.Entry(composite).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    else
                    {
                        response.message = "Composite Product  with id " + cId + " does not exist";
                        response.statusCode = "401";
                    }
                    


                    response.message = "Product  with id " + prod.PRODUCT_ID + " successfully updated";
                    response.statusCode = "200";
                }
                else
                {
                    response.message = "Product  with id " +id+ " does not exist";
                    response.statusCode = "401";
                }
                
                
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