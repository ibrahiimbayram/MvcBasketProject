using Entity.Tables;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcces.Context
{
    public class DataContext : DbContext
    {
        public DbSet<Users> Users { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<UserBasket> userBaskets { get; set; }
        public DbSet<Language> Languages { get; set; }

        public DataContext() : base("Data") { }
    }
}
