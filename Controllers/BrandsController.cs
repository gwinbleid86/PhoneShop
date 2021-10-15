using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PhoneShop.Interfaces;
using PhoneShop.Models;
using PhoneShop.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PhoneShop.Controllers
{
    public class BrandsController : Controller
    {
        private readonly IBrandsService service;

        public BrandsController(IBrandsService service)
        {
            this.service = service;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(service.GetAll().ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Brand company)
        {
            if (company != null)
            {
                await service.Create(company);
            }

            return RedirectToAction("Index");
        }
    }
}
