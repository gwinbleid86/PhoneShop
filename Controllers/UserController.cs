using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PhoneShop.enums;
using PhoneShop.Models;
using PhoneShop.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PhoneShop.Controllers
{
    public class UserController : Controller
    {
        private ApplicationContext _context;

        public UserController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: /<controller>/
        public async Task<IActionResult> Index(int brandId, string name, SortState sortOrder = SortState.NameAsc)
        {
            /*IQueryable<User> users = _context.Users.Include(e => e.Brand);
            ViewBag.NameSort = sortOrder == SortState.NameAsc ? SortState.NameDesc : SortState.NameAsc;
            ViewBag.AgeSort = sortOrder == SortState.AgeAsc ? SortState.AgeDesc : SortState.AgeAsc;
            ViewBag.BrandSort = sortOrder == SortState.BrandAsc ? SortState.BrandDesc : SortState.BrandAsc;

            switch (sortOrder)
            {
                case SortState.NameDesc:
                    users = users.OrderByDescending(e => e.Name);
                    break;
                case SortState.AgeAsc:
                    users = users.OrderBy(e => e.Age);
                    break;
                case SortState.AgeDesc:
                    users = users.OrderByDescending(e => e.Age);
                    break;
                case SortState.BrandAsc:
                    users = users.OrderBy(e => e.Brand.Name);
                    break;
                case SortState.BrandDesc:
                    users = users.OrderByDescending(e => e.Brand.Name);
                    break;
                default:
                    users = users.OrderBy(e => e.Name);
                    break;
            }

            if (brandId != 0)
            {
                users = users.Where(e => e.BrandId == brandId);
            }
            if (!string.IsNullOrEmpty(name))
            {
                users = users.Where(e => e.Name.Contains(name));
            }
            List<Brand> brands = _context.Brands.ToList();
            brands.Insert(0, new Brand { Name = "All" });

            UsersListViewModel viewModel = new UsersListViewModel
            {
                Users = await users.AsNoTracking().ToListAsync(),
                Brands = new SelectList(brands, "Id", "Name"),
                Name = name
            };

            return View(viewModel);*/
            return View();
        }
    }
}
