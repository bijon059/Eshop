using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using E_Shop_Project.Models;

namespace E_Shop_Project.ViewModels
{
    public class ProductFormViewModel 
    {
        public IEnumerable<ProductCategory> ProductCategories { get; set; }

        public List<Product> Product { get; set; }

        public User User { get; set; }

        public string Name { get; set; }
       
    }
}