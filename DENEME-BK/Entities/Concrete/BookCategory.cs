﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class BookCategory : IEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }

         public virtual List<BookType> BookTypes { get; set; } = new List<BookType>();
    }
}
