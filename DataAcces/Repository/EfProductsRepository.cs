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
    public class EfProductsRepository : IProductsDal
    {

        private readonly DataContext _context;
        public EfProductsRepository(DataContext context)
        {
            _context = context;
        }


        public void Add(Products products)
        {
            _context.Products.Add(products);
            _context.SaveChanges();
        }

        public List<Products> GetAll()
        {
            return _context.Products.ToList();
        }

        //public Products GetByProductId(int id)
        //{
        //    return _context.Products.Find(id);
        //}
    }
}
