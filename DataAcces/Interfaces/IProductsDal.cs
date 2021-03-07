using Entity.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcces.Interfaces
{
    public interface IProductsDal
    {
        void Add(Products products);
        List<Products> GetAll();

        //Products GetById(int id);
    }
}
