using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Shop_Project.Models
{
    public class Product 
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Color { get; set; }

        public int Quantity { get; set; }

        public double Price { get; set; }

        public string Description { get; set; }

        public DateTime? AddedDate { get; set; }

        public string AddedBy { get; set; }

        public ProductCategory ProductCategory { get; set; }

        public int ProductCategoryId { get; set; }


    }
}