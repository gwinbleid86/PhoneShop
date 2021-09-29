using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PhoneShop.Models;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PhoneShop.Controllers
{
    public class CommentController : Controller
    {
        private ApplicationContext _context;

        public CommentController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: /<controller>/
        //public IActionResult Add(string phoneId)
        //{
        //    Comment comment = new Comment
        //    {
        //        PhoneId = phoneId
        //    };
        //    return View(comment);
        //}

        //[HttpPost]
        //public IActionResult Add(Comment comment)
        //{
        //    if (comment != null)
        //    {
        //        Comment c = new Comment
        //        {
        //            Author = comment.Author,
        //            Rating = comment.Rating,
        //            CommentText = comment.CommentText,
        //            PhoneId = comment.PhoneId
        //        };
        //        _context.Comments.Add(c);
        //        _context.SaveChanges();
        //    }

        //    return Redirect("~/Phones/Index");
        //}


        [HttpPost]
        public async Task<JsonResult> Add(string phoneId, string author, string commentText, int rating)
        {
            Comment comment = new Comment
            {
                PhoneId = phoneId,
                Rating = rating,
                Author = author,
                CommentText = commentText
            };

            var result = _context.Comments.AddAsync(comment);
            if (result.IsCompleted)
            {
                await _context.SaveChangesAsync();
            }

            return Json(new { comment });
        }
    }
    public class CommentJson
    {
        [JsonPropertyName("phoneId")]
        public string PhoneId { get; set; }
        [JsonPropertyName("author")]
        public string Author { get; set; }
        [JsonPropertyName("commentText")]
        public string CommentText { get; set; }
        [JsonPropertyName("rating")]
        public int Rating { get; set; }
    }
}
