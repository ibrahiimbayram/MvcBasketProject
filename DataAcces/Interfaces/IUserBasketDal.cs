using Entity.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcces.Interfaces
{
    public interface IUserBasketDal
    {
        
        List<UserBasket> GetUserBaskets(string user);
        void Add(UserBasket userBasket);

        Products GetById(int id);
        void OrderCompleted(string user, int id);

        List<UserBasket> GetListOrderCompleted(string user);
        int GetQuantity(string username);

        void Delete(int id);
    }
}
