using System;
using System.Collections.Generic;

namespace PhoneShop.Models
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<User> Users { get; set; }
        public Brand()
        {
            Users = new List<User>();
        }
    }
}
