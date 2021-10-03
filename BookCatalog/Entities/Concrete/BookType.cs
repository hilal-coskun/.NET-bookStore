using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class BookType : IEntity
    {

        public int ID { get; set; }
        public string Name { get; set; }

        public int BookCategoryID { get; set; }
        public virtual BookCategory BookCategory { get; set; }

        public List<Book> Book { get; set; }


    }
}
