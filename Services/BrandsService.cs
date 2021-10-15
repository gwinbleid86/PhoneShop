using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PhoneShop.Interfaces;
using PhoneShop.Models;

namespace PhoneShop.Services
{
    public class BrandsService : IBrandsService
    {
        private readonly ApplicationContext _context;

        public BrandsService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Brand> Create(Brand o)
        {
            _context.Brands.Add(o);
            await _context.SaveChangesAsync();

            return Get(o.Id);
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Brand Get(string id)
        {
            return _context.Brands.FirstOrDefault(e => e.Id == id);
        }

        public IEnumerable<Brand> GetAll()
        {
            return _context.Brands;
        }

        public void Update(Brand o)
        {
            throw new NotImplementedException();
        }
    }
}
