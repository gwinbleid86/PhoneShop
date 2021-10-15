using System;
using System.Collections.Generic;
using PhoneShop.Models;
using PhoneShop.ViewModels;

namespace PhoneShop.Interfaces
{
    public interface ICommentService : IBaseService<Comment>
    {
        IEnumerable<Comment> GetCommentsFromPhone(string phoneId);
        CommentPageViewModel GetCommentsForPage(string phoneId, int curPage, int itemsPerPage);
    }
}
