using System;
using System.Collections.Generic;
using PhoneShop.Models;

namespace PhoneShop.ViewModels
{
    public class PhoneAndCompaniesViewModel
    {
        public Phone Phone { get; set; }
        public IEnumerable<Company> CompanyList { get; set; }
    }
}
