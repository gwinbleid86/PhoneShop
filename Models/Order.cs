using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhoneShop.Models
{
    public class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ContactPone { get; set; }

        public string PhoneId { get; set; }
        public Phone Phone { get; set; }
    }
}
