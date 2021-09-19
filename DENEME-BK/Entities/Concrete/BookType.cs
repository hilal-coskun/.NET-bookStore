using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class BookType : IEntity
    {
        public int ID { get; set; }
        public BookCategory BookCategory { get; set; }
        public int BookCategoryID { get; set; }
        public string Name { get; set; }
    }
}
