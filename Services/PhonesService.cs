using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PhoneShop.Interfaces;
using PhoneShop.Models;

namespace PhoneShop.Services
{
    public class PhonesService : IPhonesService
    {
        private readonly ApplicationContext _context;

        public PhonesService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Phone> Create(Phone o)
        {
            _context.Phones.Add(o);
            await _context.SaveChangesAsync();

            return GetWithBrand(o.Id);
        }

        public async void Delete(string id)
        {
            Phone phone = new Phone { Id = id };
            _context.Entry(phone).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public Phone GetWithBrand(string id)
        {
            return _context.Phones.Include(c => c.Brand).FirstOrDefault(e => e.Id == id);
        }

        public Phone Get(string id)
        {
            return _context.Phones.FirstOrDefault(e => e.Id == id);
        }

        public IEnumerable<Phone> GetAll()
        {
            return _context.Phones.Include(p => p.Brand).Include(c => c.Comments);
        }

        public void Update(Phone o)
        {
            _context.Phones.Update(o);
            _context.SaveChangesAsync();
        }

        public IEnumerable<Phone> SearchPhonesForKeyword(string keyWord)
        {
            return _context.Phones.Include(e => e.Brand).Where(e =>
                e.Name.Contains(keyWord) ||
                e.Brand.Name.Contains(keyWord));
        }
    }
}
