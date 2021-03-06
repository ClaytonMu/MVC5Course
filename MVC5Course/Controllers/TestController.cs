﻿using MVC5Course.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class TestController : BaseController
    {
        FabricsEntities _db = new FabricsEntities();

        // GET: Test
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult EDE()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EDE(EDEViewModel data)
        {
            return View(data);
        }

        public ActionResult CreateProduct()
        {
            var product = new Product()
            {
                ProductName = "BMW X3",
                Active = false,
                Price = 9999,
                Stock = 5
            };

            _db.Product.Add(product);
            _db.SaveChanges();
            return View(product);
        }

        //[HttpPost]
        //public ActionResult CreateProduct(Product data)
        //{
        //    var db = new FabricsEntities();
        //    _db.Product.Add(data);
        //    _db.SaveChanges();

        //    return View(data);
        //}

        public ActionResult ReadProduct(bool? active)
        {
            var data = _db.Product.AsQueryable();

            data = data
                .Where(p => p.ProductId > 1550)
                .OrderByDescending(p => p.Price);

            if (active.HasValue)
            {
                data = data.Where(p => p.Active == active);
            }

            return View(data);
        }

        public ActionResult OneProduct(int id)
        {
            var data = _db.Product
                .FirstOrDefault(p => p.ProductId == id);

            return View(data);
        }

        public ActionResult UpdateProduct(int id)
        {
            var one = _db.Product.FirstOrDefault(p => p.ProductId == id);

            if (one == null)
            {
                return HttpNotFound();
            }

            one.Price = one.Price * 2;

            try
            {
                _db.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {

                
            }
            

            return RedirectToAction("ReadProduct");
        }

        public ActionResult DeleteProduct(int id)
        {
            var one = _db.Product.FirstOrDefault(p => p.ProductId == id);

            //foreach (var item in one.OrderLine.ToList())
            //{
            //    _db.OrderLine.Remove(item);
            //}

            //_db.OrderLine.RemoveRange(one.OrderLine);

            _db.Database.ExecuteSqlCommand("DELETE dbo.OrderLine WHERE ProductId = @p0", id);


            _db.Product.Remove(one);
            _db.SaveChanges();

            return RedirectToAction("ReadProduct");
        }

        public ActionResult ProductView()
        {
            var data = _db.Database.SqlQuery<ProductViewModel>(
                @"SELECT * FROM dbo.Product WHERE Active = @p0 AND ProductName like @p1", true, "%Yellow%");

            return View(data);
        }

        public ActionResult ProductSP()
        {
            var data = _db.GetProduct(true, "%Yellow%");
            return View(data);
        }
    }
}