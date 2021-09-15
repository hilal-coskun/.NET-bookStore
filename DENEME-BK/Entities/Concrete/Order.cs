using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Order : IEntity
    {
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public int OrderStatusID { get; set; }
        public int PaymentChannelID { get; set; }
        public int OrderDetailID { get; set; }
        public System.DateTime RecordDate { get; set; }
    }
}
