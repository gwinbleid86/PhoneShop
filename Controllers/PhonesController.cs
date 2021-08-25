using System.Collections.Generic;
using System.Linq;
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
        public IActionResult Index()
        {
            List<Phone> phones = _db.Phones.Include(p => p.Company).ToList();
            return View(phones);
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
                PhoneAndCompaniesViewModel phoneVM = new PhoneAndCompaniesViewModel()
                {
                    Phone = _db.Phones.Include(c => c.Company).FirstOrDefault(p => p.Id == id),
                    CompanyList = _db.Companies.ToList()
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
                _db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
