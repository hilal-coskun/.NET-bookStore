using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class BookPublisher : IEntity
    {
        //[Required]
        public int ID { get; set; }
        public int ContactID { get; set; }
        public string About { get; set; }
        public string Name { get; set; }
        public System.DateTime RecordDate { get; set; }
    }
}
