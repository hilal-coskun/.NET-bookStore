using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IAuthorService
    {
        List<Author> GetAll();
        List<Author> GetList();
        Author GetById(int authorId);
        Author GetByID(int? authorId);
        List<Author> SearchFilter(string Empsearch);
        List<Author> GetListCategory(int authorId);
        void Add(Author author);
        void Delete(Author author);
        void Update(Author author);
    }
}
