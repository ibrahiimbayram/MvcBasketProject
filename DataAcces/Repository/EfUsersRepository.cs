using DataAcces.Context;
using DataAcces.Interfaces;
using Entity.Tables;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcces.Repository
{
    public class EfUsersRepository : IUsersDal
    {
        private readonly DataContext _context;
        public EfUsersRepository(DataContext context)
        {
            _context = context;
        }

        public void Add(Users users)
        {
            _context.Users.Add(users);
            _context.SaveChanges();
        }

        public List<Users> GetAll()
        {
            return _context.Users.ToList();
        }

        public Users GetFindUser(string username)
        {
            return _context.Users.Where(I => I.UserName == username).FirstOrDefault();
        }
        public Users LoginUsers(string username, string password)
        {
            return _context.Users.Where(I => I.UserName == username&&I.Password==password).FirstOrDefault();
        }

        public void Remove(Users users)
        {
            _context.Users.Remove(users);
            _context.SaveChanges();
        }

        public void Update(Users users)
        {
            _context.Users.Attach(users);
            _context.Entry(users).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
