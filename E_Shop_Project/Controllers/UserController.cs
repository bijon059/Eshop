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
    public class UserController : Controller
    {
        //GET: User

        private ApplicationDbContext _context;

        public UserController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }



        public ActionResult Index()
        {
            return View();
        }

        public ActionResult New()
        {
            var userCategory = _context.UserCategories.ToList();

            var viewModel = new UserFormViewModel
            {
                UserCategories = userCategory
            };


            return View("New", viewModel);
        }

        [HttpPost]
        public ActionResult Save(User user)
        {
            user.ErrorloginAtempt = 5;
            //if (user.Id == 0)
            //{
            //    _context.Users.Add(user);
            //}
            //else
            //{
            //    var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);

            //    customerInDb.Name = customer.Name;
            //    customerInDb.Birthdate = customer.Birthdate;
            //    customerInDb.MembershipTypeId = customer.MembershipTypeId;
            //    customerInDb.IsSubscribeToNewsLetter = customer.IsSubscribeToNewsLetter;
            //}
            _context.Users.Add(user);
            _context.SaveChanges();

            return RedirectToAction("Index", "User");
        }


        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Home(User user)
        {


            var userInDb = _context.Users.Include(c => c.UserCategories).Single(c => c.UserName == user.UserName);
            if (userInDb.UserCategoryId == 2)
            {
                if (userInDb.Password == user.Password)
                {

                    return View(userInDb);
                }
                else
                {
                    userInDb.ErrorloginAtempt--;
                    _context.SaveChanges();
                    return HttpNotFound("Password Is Incorrect");
                }
            }
            else
            {
                if (userInDb.Password == user.Password)
                {
                    var productInDb = _context.Products.Include(t => t.ProductCategory).ToList();
                    var viewModel = new ProductFormViewModel
                    {
                        User = userInDb,
                        Product = productInDb  
                    };

                    return View("Admin", viewModel);
                }

                else
                {
                    userInDb.ErrorloginAtempt--;
                    _context.SaveChanges();
                    return HttpNotFound("Password Is Incorrect");
                }
            }

        }
    }
    }