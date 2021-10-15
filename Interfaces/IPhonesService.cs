using System;
using System.Collections.Generic;
using PhoneShop.Models;

namespace PhoneShop.Interfaces
{
    public interface IPhonesService : IBaseService<Phone>
    {
        Phone GetWithBrand(string id);
        IEnumerable<Phone> SearchPhonesForKeyword(string keyWord);
    }
}
