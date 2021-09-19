using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class OrderDetail : IEntity
    {
        public int ID { get; set; }
        public int BookID { get; set; }
        public int OrderAmount { get; set; }
        public System.DateTime RecordDate { get; set; }
    }
}
