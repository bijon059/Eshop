using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Shop_Project.Models;
using E_Shop_Project.ViewModels;

namespace E_Shop_Project.Controllers
{
    public class ProductController : Controller
    {
         //GET: Product

        private ApplicationDbContext _context;

        public ProductController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult AddProduct(User user)
        {
            var userInDb = _context.Users.Include(x=>x.Products).Single(c => c.Name == user.Name);
            var db = _context.ProductCategories.ToList();
            

            //string name = userInDb.Name;

            var mdel = new ProductFormViewModel
            {
                ProductCategories = db,
                Name = userInDb.Name
            };

            return View("New",mdel);
        }

        [HttpPost]
        public ActionResult Save(Product product, string name)
        {
            product.AddedBy = name;
            product.AddedDate= DateTime.Now;

            _context.Products.Add(product);
            _context.SaveChanges();
            //productsInDb.AddedBy = productForm.User.Name;
            //productsInDb.Name = productForm.Product.Name;
            //productsInDb.AddedDate= DateTime.Now;
            //productsInDb.Color = productForm.Product.Color;
            //productsInDb.Description = productForm.Product.Description;
            //productsInDb.Price = productForm.Product.Price;
            //productsInDb.Quantity = productForm.Product.Quantity;
            //productsInDb.ProductCategoryId = productForm.Product.ProductCategoryId;

            //if (customer.Id == 0)
            //{
            //    _context.Customers.Add(customer);
            //}
            //else
            //{
            //    var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);

            //    customerInDb.Name = customer.Name;
            //    customerInDb.BirthDate = customer.BirthDate;
            //    customerInDb.MembershipTypeId = customer.MembershipTypeId;
            //    customerInDb.IsSubscribeToNewsLetter = customer.IsSubscribeToNewsLetter;

            //}
           
            return View("New");
        }

    }
}