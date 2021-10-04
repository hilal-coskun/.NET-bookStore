using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPaperTypeService
    {
        List<PaperType> GetAll();
        List<PaperType> GetList();
        PaperType GetById(int paperTypeId);
        List<PaperType> GetListCategory(int paperTypeId);
        void Add(PaperType paperType);
        void Delete(PaperType paperType);
        void Update(PaperType paperType);
    }
}
