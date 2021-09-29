using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhoneShop.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _49.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private ApplicationContext _context;

        public OrdersController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Order> orders = _context.Orders.Include(o => o.Phone).ToList();
            return View(orders);
        }

        public IActionResult Create(string id)
        {
            Phone phone = _context.Phones.FirstOrDefault(p => p.Id == id);
            return View(new Order { Phone = phone });
        }

        [HttpPost]
        public IActionResult Create(Order order)
        {
            if (order != null)
            {
                _context.Orders.Add(order);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
