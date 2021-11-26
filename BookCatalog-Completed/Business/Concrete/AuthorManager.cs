using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class AuthorManager : IAuthorService
    {
        private IAuthorDal _authorDal;

        public AuthorManager(IAuthorDal authorDal)
        {
            _authorDal = authorDal;
        }

        public List<Author> GetAll()
        {
            return _authorDal.GetList().ToList();
        }

        public Author GetById(int authorId)
        {
            return _authorDal.Get(p => p.ID == authorId);
        }

        public Author GetByID(int? authorId)
        {
            return _authorDal.Get(p => p.ID == authorId);
        }

        public List<Author> GetList()
        {
            return _authorDal.GetList().ToList();
        }

        public List<Author> GetListCategory(int authorId)
        {
            return _authorDal.GetList(b => b.ID == authorId).ToList();
        }

        public void Add(Author author)
        {
            _authorDal.Add(author);
        }

        public void Delete(Author author)
        {
            _authorDal.Delete(author);
        }

        public void Update(Author author)
        {
            _authorDal.Update(author);
        }

        public List<Author> SearchFilter(string Empsearch)
        {
            return _authorDal.SearchFilter(Empsearch);
        }
    }
}
