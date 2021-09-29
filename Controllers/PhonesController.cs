using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhoneShop.Models;
using PhoneShop.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PhoneShop.Controllers
{
    public class PhonesController : Controller
    {
        private ApplicationContext _db;

        public PhonesController(ApplicationContext db)
        {
            _db = db;
        }


        // GET: /<controller>/
        public async Task<IActionResult> Index(int page = 1)
        {
            int pageSize = 3;
            IQueryable<Phone> source = _db.Phones.Include(p => p.Brand).Include(c => c.Comments);
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
                BrandList = _db.Brands.ToList()
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
                    _db.Phones.Add(phoneVM.Phone);
                    _db.SaveChanges();
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
                    Phone = _db.Phones.Include(c => c.Brand).FirstOrDefault(p => p.Id == id),
                    BrandList = _db.Brands.ToList(),
                    Comments = _db.Comments.Where(e => e.PhoneId == id).ToList()
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
                _db.Phones.Update(phone);
                _db.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }



        // Delete actions
        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(string id)
        {
            if (id != null)
            {
                Phone phone = await _db.Phones.FirstOrDefaultAsync(e => e.Id == id);
                if (phone != null)
                {
                    return View(phone);
                }
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            if (id != null)
            {
                Phone phone = new Phone { Id = id };
                _db.Entry(phone).State = EntityState.Deleted;
                await _db.SaveChangesAsync();
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
            List<Phone> phones = _db.Phones.Include(e => e.Brand).Where(e =>
                e.Name.Contains(keyWord) ||
                e.Brand.Name.Contains(keyWord)).ToList();
            return PartialView("PartialViews/_PhonesPartial", phones);
        }
    }
}
