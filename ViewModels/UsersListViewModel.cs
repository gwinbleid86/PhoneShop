using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using PhoneShop.Models;

namespace PhoneShop.ViewModels
{
    public class UsersListViewModel
    {
        public IEnumerable<User> Users { get; set; }
        public SelectList Brands { get; set; }
        public string Name { get; set; }
    }
}
