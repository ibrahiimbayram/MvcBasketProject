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
    public class EfLanguageRepository : ILanguageDal
    {
        private readonly DataContext _context;
        public EfLanguageRepository(DataContext context)
        {
            _context = context;
        }
        public Language GetLanguages(string Name)
        {
           return _context.Languages.Where(I => I.Name == Name).FirstOrDefault();
        }
    }
}
