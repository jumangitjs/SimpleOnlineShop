using System.Collections.Generic;

namespace SimpleOnlineShop.SimpleOnlineShop.Application
{
    public interface IService
    {
        IData RetriveById(long id);

        IEnumerable<IData> RetrieveAll();
    }
}