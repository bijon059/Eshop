using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_Shop_Project.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        public string Address { get; set; }


        public short ErrorloginAtempt { get; set; }


        public UserCategory UserCategories { get; set; }


        [Display(Name = "User Category")]
        public int UserCategoryId { get; set; }

        public List<Product> Products { get; set; }

    }
}