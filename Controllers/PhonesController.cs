using System.Linq;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add()
        {
            var phoneAndCompanies = new PhoneAndCompaniesViewModel
            {
                //Phone = new Phone(),
                CompanyList = _db.Companies.ToList()
            };
            return View(phoneAndCompanies);
        }

        [HttpPost]
        public IActionResult Add(PhoneAndCompaniesViewModel phoneVM)
        {
            if (phoneVM != null)
            {
                _db.Phones.Add(phoneVM.Phone);
                _db.SaveChanges();
            }


            return RedirectToAction("index");
        }

        public IActionResult Edit(int? id)
        {
            if (id != null)
            {
                Phone phone = _db.Phones.FirstOrDefault(p => p.Id == id);
                if (phone != null)
                {
                    return View(phone);
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
                _db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
