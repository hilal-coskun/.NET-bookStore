using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ITranslatorService
    {
        Translator GetById(int translatorId);
        List<Translator> GetAll(); 
        List<Translator> GetList();
        List<Translator> SearchFilter(string Empsearch);
        List<Translator> GetListCategory(int translatorId);
        void Add(Translator translator, string dosyayolu);
        void Delete(Translator translator);
        void Update(Translator translator);
        void UpdateImage(Translator translator, string dosyayolu);
    }
}


