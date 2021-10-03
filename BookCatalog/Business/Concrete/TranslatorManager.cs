using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class TranslatorManager : ITranslatorService
    {
        private ITranslatorDal _translatorDal;

        public TranslatorManager(ITranslatorDal translatorDal)
        {
            _translatorDal = translatorDal;
        }

        public List<Translator> GetAll()
        {
            return _translatorDal.GetList().ToList();
        }

        public Translator GetById(int translatorId)
        {
            return _translatorDal.Get(p => p.ID == translatorId);
        }


        public List<Translator> GetList()
        {
            return _translatorDal.GetList().ToList();
        }

        public List<Translator> GetListCategory(int translatorId)
        {
            return _translatorDal.GetList(b => b.ID == translatorId).ToList();
        }

        public void Add(Translator translator)
        {
            //business code
            _translatorDal.Add(translator);
        }

        public void Delete(Translator translator)
        {
            _translatorDal.Delete(translator);
        }

        public void Update(Translator translator)
        {
            _translatorDal.Update(translator);
        }

        public List<Translator> SearchFilter(string Empsearch)
        {
            return _translatorDal.SearchFilter(Empsearch);
        }
    }
}
