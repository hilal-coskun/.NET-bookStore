﻿using Core.DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IBookCategoryDal : IEntityRepository<BookCategory>
    {
        //List<BookType> GetBookCategory(BookCategory bookCategory);
    }
}
