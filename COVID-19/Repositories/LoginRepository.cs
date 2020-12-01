<<<<<<< HEAD
﻿using COVID_19.Context;
using COVID_19.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COVID_19.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private COVID_Context context;
        public LoginRepository(COVID_Context _context) {
            context = _context;
        }

        public Login GetLogin(Login login)
        {
            var resultado = context.logins.Where(l => l.usuario == login.usuario && l.senha == login.senha).FirstOrDefault();
            if (resultado != null)
            {
                // criar contexto no banco de dados
                //fazer o consulta.
                login.id = resultado.id;
                login.senha = resultado.senha;
                login.grupo = resultado.grupo;
                return login;
            }
            return null;
        }

    }
}
=======
﻿using COVID_19.Context;
using COVID_19.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COVID_19.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private COVID_Context context;
        public LoginRepository() {
            context = new COVID_Context();
        }

        public Login GetLogin(Login login)
        {
            var resultado = context.LOGINS.Where(l => l.usuario == login.usuario && l.senha == login.senha).FirstOrDefault();
            if (resultado != null)
            {
                // criar contexto ai no banco de dados
                //fazer o consulta.
                login.id = resultado.id;
                login.grupo = resultado.grupo;
                return login;
            }
            return null;
        }

    }
}
>>>>>>> 558924129279b0eac27cda33037ed099f7c5527c
