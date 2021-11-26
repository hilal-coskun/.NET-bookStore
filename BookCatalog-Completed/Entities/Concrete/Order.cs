using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Concrete
{
    public class Order : IEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int ContactID { get; set; }
        public Contact Contact { get; set; }
        public int BookID { get; set; }
        public Book Book { get; set; }
        public int OrderStatusID { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public int PaymentChannelID { get; set; }
        public PaymentChannel PaymentChannel { get; set; }
        public int NumberOfBook { get; set; }

        public DateTime RecordDate { get; set; }
        public Order()
        {
            RecordDate = DateTime.Now;
        }
    }
}
