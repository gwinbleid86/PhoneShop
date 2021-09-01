using System;
namespace PhoneShop.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public string Author { get; set; }
        public string CommentText { get; set; }

        public int PhoneId { get; set; }
        public Phone Phone { get; set; }
    }
}
