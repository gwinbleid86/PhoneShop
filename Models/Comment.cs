using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhoneShop.Models
{
    public class Comment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public int Rating { get; set; }
        public string Author { get; set; }
        public string CommentText { get; set; }

        public string PhoneId { get; set; }
        public Phone Phone { get; set; }
    }
}
