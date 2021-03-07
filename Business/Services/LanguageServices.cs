using DataAcces.Interfaces;
using Entity.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class LanguageServices
    {
        private readonly ILanguageDal _languageDal;

        public LanguageServices(ILanguageDal languageDal)
        {
            _languageDal = languageDal;
        }


        public Language GetLanguages(string Name)
        {
            return _languageDal.GetLanguages(Name);
        }
    }
}
