using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PhoneShop.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PhoneShop.Controllers
{
    public class BrandsController : Controller
    {
        private ApplicationContext _context;

        public BrandsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Brand> companies = _context.Brands.ToList();
            return View(companies);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Brand company)
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
