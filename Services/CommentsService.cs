using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PhoneShop.Interfaces;
using PhoneShop.Models;
using PhoneShop.ViewModels;

namespace PhoneShop.Services
{
    public class CommentsService : ICommentService
    {
        private readonly ApplicationContext _context;

        public CommentsService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Comment> Create(Comment o)
        {
            Comment comment = new Comment
            {
                PhoneId = o.PhoneId,
                Rating = o.Rating,
                Author = o.Author,
                CommentText = o.CommentText
            };

            var result = _context.Comments.AddAsync(comment);
            if (result.IsCompleted)
            {
                await _context.SaveChangesAsync();
            }

            return Get(comment.Id);
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Comment Get(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Comment> GetAll()
        {
            return _context.Comments;
        }

        public void Update(Comment o)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Comment> GetCommentsFromPhone(string phoneId)
        {
            return _context.Comments.Where(e => e.PhoneId == phoneId);
        }

        public CommentPageViewModel GetCommentsForPage(string phoneId, int curPage, int itemsPerPage)
        {
            var comments = GetCommentsFromPhone(phoneId).ToList();

            var maxPage = (int)Math.Ceiling((double)comments.Count / itemsPerPage);

            List<Comment> page = new List<Comment>();

            if (curPage == 1)
            {
                page = comments.Take(itemsPerPage).ToList();
            }
            else if (curPage > 1 && curPage < maxPage)
            {
                page = comments.Skip((curPage - 1) * itemsPerPage).Take(itemsPerPage).ToList();
            }
            else
            {
                page = comments.Skip((maxPage - 1) * itemsPerPage).Take(itemsPerPage).ToList();
            }

            CommentPageViewModel model = new CommentPageViewModel
            {
                Comments = page,
                CurPage = curPage,
                MaxPage = maxPage
            };

            return model;
        }
    }
}
