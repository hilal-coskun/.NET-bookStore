using Core.DataAccess.Concrete.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfTranslatorDal : EfEntityRepositoryBase<Translator, BookCatalogContext>, ITranslatorDal
    {
        public List<Translator> SearchFilter(string Empsearch)
        {
            using (var context = new BookCatalogContext())
            {
                return context.Translator.Where(i => i.Name.Contains(Empsearch)).ToList();
            }
        }
    }
}
