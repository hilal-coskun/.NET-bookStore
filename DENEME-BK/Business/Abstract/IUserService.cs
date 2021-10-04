using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        //User GetById(int userId);
        //User GetByID(int? userId);
        User LoginProcess(string username, string password);
        User SendCodeProcess(string email);
        //List<User> GetList();
        //List<User> GetAll();
        //List<User> GetListCategory(int userId);
        void Add(User user);
        void AddCode(PasswordCode passwordCode);
        void Delete(User user);
        void Update(User user);
    }
}
