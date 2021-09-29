using System;
using System.Collections.Generic;
using PhoneShop.Models;

namespace PhoneShop.ViewModels
{
    public class PhoneIndexViewModel
    {
        public IEnumerable<Phone> Phones { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}
