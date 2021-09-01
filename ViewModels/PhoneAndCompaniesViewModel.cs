using System;
using System.Collections.Generic;
using PhoneShop.Models;

namespace PhoneShop.ViewModels
{
    public class PhoneAndCompaniesViewModel
    {
        public Phone Phone { get; set; }
        public IEnumerable<Brand> BrandList { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
    }
}
