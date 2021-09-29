using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhoneShop.Models
{
    public class Phone
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Range(100, 70000)]
        public int Price { get; set; }

        [Required]
        public string BrandId { get; set; }
        public Brand Brand { get; set; }

        public List<Comment> Comments { get; set; }

        public Phone()
        {
            Comments = new List<Comment>();
        }
    }
}
