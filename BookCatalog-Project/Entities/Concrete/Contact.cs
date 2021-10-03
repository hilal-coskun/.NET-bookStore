using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Contact : IEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        //public bool IsCorporation { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }

        public DateTime RecordDate { get; set; }
        public Contact()
        {
            RecordDate = DateTime.Now;
        }

        public List<BookPublisher> BookPublisher { get; set; }
        public List<Order> Order { get; set; }
    }
}
