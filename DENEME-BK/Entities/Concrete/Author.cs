using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Author : IEntity
    {
        public int ID { get; set; }
        //[Required]
        public string Name { get; set; }
        public string About { get; set; }
        public System.DateTime RecordDate { get; set; }
    }
}
