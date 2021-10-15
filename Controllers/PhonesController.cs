using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhoneShop.Interfaces;
using PhoneShop.Models;
using PhoneShop.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PhoneShop.Controllers
{
    public class PhonesController : Controller
    {
        private readonly IPhonesService phoneService;
        private readonly IBrandsService brandService;
        private readonly ICommentService commentService;

        public PhonesController(IPhonesService phoneService, IBrandsService brandService, ICommentService commentService)
        {
            this.phoneService = phoneService;
            this.brandService = brandService;
            this.commentService = commentService;
        }

        // GET: /<controller>/
        public async Task<IActionResult> Index(int page = 1)
        {
            int pageSize = 3;
            IQueryable<Phone> source = phoneService.GetAll().AsQueryable();
            var count = await source.CountAsync();
            var items = await source.Skip((page - 1)*pageSize).Take(pageSize).ToListAsync();
            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);

            PhoneIndexViewModel model = new PhoneIndexViewModel
            {
                PageViewModel = pageViewModel,
                Phones = items
            };

            return View(model);
        }

        [Authorize(Roles = "admin")]
        public IActionResult Add()
        {
            var phoneAndCompanies = new PhoneAndCompaniesViewModel
            {
                BrandList = brandService.GetAll()
            };
            return View(phoneAndCompanies);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult Add(PhoneAndCompaniesViewModel phoneVM)
        {

            if (ModelState.IsValid)
            {
                if (phoneVM != null)
                {
                    phoneService.Create(phoneVM.Phone);
                }
                return RedirectToAction("Index");
            }
            return RedirectToAction("Add");
        }

        // Edit actions
        public IActionResult Edit(string id)
        {
            if (id != null)
            {
                PhoneAndCompaniesViewModel phoneVM = new PhoneAndCompaniesViewModel()
                {
                    Phone = phoneService.Get(id),
                    BrandList = brandService.GetAll(),
                    Comments = commentService.GetCommentsFromPhone(id).ToList()
                };
                if (phoneVM.Phone != null)
                {
                    return View(phoneVM);
                }
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Edit(Phone phone)
        {
            if (phone != null)
            {
                phoneService.Update(phone);
            }

            return RedirectToAction("Index");
        }



        // Delete actions
        [HttpGet]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(string id)
        {
            if (id != null)
            {
                Phone phone = phoneService.Get(id);
                if (phone != null)
                {
                    return View(phone);
                }
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Delete(string id)
        {
            if (id != null)
            {
                phoneService.Delete(id);
                return RedirectToAction("Index");
            }
            return NotFound();
        }

        public IActionResult Search()
        {
            return View();
        }

        public IActionResult SearchResult(string keyWord)
        {
            return PartialView("PartialViews/_PhonesPartial", phoneService.SearchPhonesForKeyword(keyWord));
        }
    }
}
