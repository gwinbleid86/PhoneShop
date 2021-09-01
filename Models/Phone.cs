using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PhoneShop.Models
{
    public class Phone
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Range(100, 70000)]
        public int Price { get; set; }

        [Required]
        public int BrandId { get; set; }
        public Brand Brand { get; set; }

        public List<Comment> Comments { get; set; }

        public Phone()
        {
            Comments = new List<Comment>();
        }
    }
}
