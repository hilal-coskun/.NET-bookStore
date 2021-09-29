using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ITranslatorService
    {
        List<Translator> GetAll(); 
        Translator GetById(int translatorId);
        List<Translator> GetList();
        List<Translator> GetListCategory(int translatorId);
        void Add(Translator translator);
        void Delete(Translator translator);
        void Update(Translator translator);
    }
}


