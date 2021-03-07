using DataAcces.Context;
using DataAcces.Interfaces;
using Entity.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcces.Repository
{
    public class EfUserBasketRepository : IUserBasketDal
    {
        private readonly DataContext _dataContext;
        public EfUserBasketRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Add(UserBasket userBasket)
        {
            _dataContext.userBaskets.Add(userBasket);
            _dataContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var user= _dataContext.userBaskets.Find(id);
            _dataContext.userBaskets.Remove(user);
            _dataContext.SaveChanges();
        }

        public Products GetById(int id)
        {
           return _dataContext.Products.Find(id);
        }

        public List<UserBasket> GetListOrderCompleted(string user)
        {
            return _dataContext.userBaskets.Where(I => I.UserName == user && I.Order == "Completed").ToList();
        }

        public int GetQuantity(string username)
        {




            return _dataContext.userBaskets.Where(I => I.UserName == username && I.Order == "NotCompleted").Sum(I => I.Quantity);
        }

        public List<UserBasket> GetUserBaskets(string user)
        {
            return _dataContext.userBaskets.Where(I => I.UserName == user&&I.Order=="NotCompleted").ToList();
        }

        public void OrderCompleted(string user, int id)
        {

            var result = _dataContext.userBaskets.Where(I => I.UserName == user && I.Id == id).FirstOrDefault();

            result.Order = "Completed";
            _dataContext.SaveChanges();
        }
    }
}
