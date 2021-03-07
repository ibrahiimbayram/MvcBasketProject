using DataAcces.Interfaces;
using Entity.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace Business.Services
{
    public class LoginServices
    {
        private readonly IUsersDal _usersDal;
        public LoginServices(IUsersDal usersDal)
        {
            _usersDal = usersDal;
        }

        public Users SignUp(Users users)
        {
             _usersDal.Add(users);
            //if (FindUser != null)
            //{
            //    _usersDal.Add(users);
            //}
            //_usersDal.Add(users);
            return null;
        }

        public Users GetFindUser(string username)
        {
          return  _usersDal.GetFindUser(username);
        }

        private class LoginUser
        {
            public string UserName { get; set; }
            public string Password { get; set; }
        }

        public Users Login(Users users)
        {



            return _usersDal.LoginUsers(users.UserName, users.Password);
        }

     
        public List<Users> Get()
        {
            var FindUser = _usersDal.GetAll();
            //if (FindUser != null)
            //{
            //    _usersDal.Add(users);
            //}
            //_usersDal.Add(users);
            return FindUser;
        }

 
    }
}
