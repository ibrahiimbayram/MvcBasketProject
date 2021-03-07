using Entity.Interfaces;
using Entity.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcces.Interfaces
{
    public interface IUsersDal
    {
        Users LoginUsers(string username, string password);
        Users GetFindUser(string username);
        List<Users> GetAll();
        void Add(Users users);
        void Update(Users users);
        void Remove(Users users);

  
    }
}
