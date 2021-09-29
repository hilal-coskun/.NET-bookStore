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
    public class PaperTypeManager :IPaperTypeService
    {
        private IPaperTypeDal _paperTypeDal;

        public PaperTypeManager(IPaperTypeDal paperTypeDal)
        {
            _paperTypeDal = paperTypeDal;
        }


        public PaperType GetById(int paperTypeId)
        {
            return _paperTypeDal.Get(p => p.ID == paperTypeId);
        }

        public PaperType GetByID(int? paperTypeId)
        {
            return _paperTypeDal.Get(p => p.ID == paperTypeId);
        }

        public List<PaperType> GetAll()
        {
            return _paperTypeDal.GetList().ToList();
        }

        public PaperType GetByID(int paperTypeId)
        {
            return _paperTypeDal.Get(p => p.ID == paperTypeId);
        }

        public List<PaperType> GetList()
        {
            return _paperTypeDal.GetList().ToList();
        }

        public List<PaperType> GetListCategory(int paperTypeId)
        {
            return _paperTypeDal.GetList(b => b.ID == paperTypeId).ToList();
        }

        public void Add(PaperType paperType)
        {
            //business code
            _paperTypeDal.Add(paperType);
        }

        public void Delete(PaperType paperType)
        {
            _paperTypeDal.Delete(paperType);
        }

        public void Update(PaperType paperType)
        {
            _paperTypeDal.Update(paperType);
        }
    }
}
