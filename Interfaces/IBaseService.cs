using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneShop.Interfaces
{
    public interface IBaseService<T>
    {
        IEnumerable<T> GetAll();

        T Get(string id);

        Task<T> Create(T o);

        void Update(T o);

        void Delete(string id);
    }
}
