using System;
using Microsoft.AspNetCore.Identity;

namespace PhoneShop.Models
{
    public class User : IdentityUser
    {
        
        public DateTime DateOfBirth { get; set; }

        public string BrandId { get; set; }
        public Brand Brand { get; set; }
    }
}
