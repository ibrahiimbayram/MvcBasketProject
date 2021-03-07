using DataAcces.Interfaces;
using Entity.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class ProductServices
    {
        private readonly IProductsDal _productsDal;

        public ProductServices(IProductsDal productsDal)
        {
            _productsDal = productsDal;
        }


        public Products Add(Products products)
        {
            _productsDal.Add(products);
            return null;
        }

        public List<Products> GetProducts()
        {
            return _productsDal.GetAll();
        }
    }
}
