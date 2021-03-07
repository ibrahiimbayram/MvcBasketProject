using DataAcces.Interfaces;
using Entity.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class UserBasketServices
    {
        private readonly IUserBasketDal _userBasket;

        public UserBasketServices(IUserBasketDal userBasket)
        {
            _userBasket = userBasket;
        }

        public UserBasket Add(UserBasket userBasket)
        {
            _userBasket.Add(userBasket);
            return null;
        }


        public List<UserBasket> List(string user)
        {
            
            return _userBasket.GetUserBaskets(user);
        }


        public Products GetById(int id)
        {
            return _userBasket.GetById(id);
        }

        public UserBasket OrderCompleted(string user,int id)
        {
            _userBasket.OrderCompleted(user, id);
            return null;
        }


        public int GetQuantity(string user)
        {
            
            return _userBasket.GetQuantity(user);
        }


        public List<UserBasket> GetListOrderCompleted(string user)
        {

            return _userBasket.GetListOrderCompleted(user);
        }

        public void Delete(int id)
        {
            _userBasket.Delete(id);
        }
    }
}
