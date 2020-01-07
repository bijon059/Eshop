using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using E_Shop_Project.Models;

namespace E_Shop_Project.ViewModels
{
    public class UserFormViewModel
    {
        public IEnumerable<UserCategory> UserCategories { get; set; }

        public User User { get; set; }
    }
}