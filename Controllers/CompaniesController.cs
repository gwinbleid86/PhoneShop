using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PhoneShop.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PhoneShop.Controllers
{
    public class CompaniesController : Controller
    {
        private ApplicationContext _context;

        public CompaniesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Company> companies = _context.Companies.ToList();
            return View(companies);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Company company)
        {
            if (company != null)
            {
                _context.Add(company);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
