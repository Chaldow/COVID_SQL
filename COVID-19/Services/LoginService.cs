using COVID_19.Models;
using COVID_19.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COVID_19.Services
{
    public class LoginService : ILoginService
    {
        private ILoginRepository _repository;
        public LoginService(ILoginRepository repository)
        {
            _repository = repository;
        }
        public Login GetLogin(Login login)
        {
            return _repository.GetLogin(login);
        }
    }
}
