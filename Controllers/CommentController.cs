using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PhoneShop.Models;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using PhoneShop.ViewModels;
using PhoneShop.Services;
using PhoneShop.Interfaces;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PhoneShop.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService service;

        public CommentController(ICommentService service)
        {
            this.service = service;
        }

        [HttpPost]
        public async Task<JsonResult> Add(Comment inputComment)
        {
            return Json(new { Comment = await service.Create(inputComment) });
        }


        public JsonResult AllComments(string phoneId, int curPage, int itemsPerPage)
        {
            return Json(new { CommentPageViewModel = service.GetCommentsForPage(phoneId, curPage, itemsPerPage) });
        }
    }

}
