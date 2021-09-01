using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PhoneShop.Models;

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
        public IActionResult Add(int phoneId)
        {
            Comment comment = new Comment
            {
                PhoneId = phoneId
            };
            return View(comment);
        }

        [HttpPost]
        public IActionResult Add(Comment comment)
        {
            if (comment != null)
            {
                Comment c = new Comment
                {
                    Author = comment.Author,
                    Rating = comment.Rating,
                    CommentText = comment.CommentText,
                    PhoneId = comment.PhoneId
                };
                _context.Comments.Add(c);
                _context.SaveChanges();
            }

            return Redirect("~/Phones/Index");
        }
    }
}
