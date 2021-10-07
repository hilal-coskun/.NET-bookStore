using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Customer: IEntity
    {
        public int ID { get; set; }
        public int ContactID { get; set; }
        public System.DateTime RecordDate { get; set; }

        public List<Order> Order { get; set; }
    }
}
