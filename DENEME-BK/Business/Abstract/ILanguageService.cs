using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ILanguageService
    {
        List<Language> GetAll();
        List<Language> GetList();
        Language GetById(int languageId);
        List<Language> GetListCategory(int languageId);
        void Add(Language language);
        void Delete(Language language);
        void Update(Language language);
    }
}
