using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class LanguageManager :ILanguageService
    {
        private ILanguageDal _languageDal;

        public LanguageManager(ILanguageDal languageDal)
        {
            _languageDal = languageDal;
        }


        public Language GetById(int languageId)
        {
            return _languageDal.Get(p => p.ID == languageId);
        }

        public Language GetByID(int? languageId)
        {
            return _languageDal.Get(p => p.ID == languageId);
        }

        public List<Language> GetAll()
        {
            return _languageDal.GetList().ToList();
        }

        public Language GetByID(int languageId)
        {
            return _languageDal.Get(p => p.ID == languageId);
        }

        public List<Language> GetList()
        {
            return _languageDal.GetList().ToList();
        }

        public List<Language> GetListCategory(int languageId)
        {
            return _languageDal.GetList(b => b.ID == languageId).ToList();
        }

        public void Add(Language language)
        {
            //business code
            _languageDal.Add(language);
        }

        public void Delete(Language language)
        {
            _languageDal.Delete(language);
        }

        public void Update(Language language)
        {
            _languageDal.Update(language);
        }
    }
}
