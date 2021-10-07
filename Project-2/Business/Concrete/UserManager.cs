using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {

        private IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }


        public User GetById(int userId)
        {
            return _userDal.Get(p => p.Id == userId);
        }

        public User GetByID(int? userId)
        {
            return _userDal.Get(p => p.Id == userId);
        }

        public User LoginProcess(string username, string password)
        {
            var user = _userDal.Get(a => a.Username.Equals(username) && a.Password.Equals(password));
            return user;
        }

        public void Add(User user)
        {
            //business code
            _userDal.Add(user);
        }

        public void Delete(User user)
        {
            _userDal.Delete(user);
        }

        public void Update(User user)
        {
            _userDal.Update(user);
        }

        public User SendCodeProcess(string email)
        {
            var send = _userDal.Get(w => w.Email.Equals(email));

            return send;
        }

        public void AddCode(PasswordCode passwordCode)
        {
            //_userDal.Add(passwordCode);
        }
    }
}
