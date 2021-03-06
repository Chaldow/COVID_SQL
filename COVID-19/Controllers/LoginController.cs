
﻿using COVID_19.Models;
using COVID_19.Repositories;
using COVID_19.Services;
using COVID_19.Tokens;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COVID_19.Controllers
{  [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _services;


        public LoginController(ILoginService services)
        {
            _services = services;
        }


        [AllowAnonymous]
        [HttpPost]
        [Route("autenticacao")]
         public async Task<ActionResult<dynamic>> Authenticate([FromBody] Login login)
        {
            var usuario = _services.GetLogin(login);
            if (usuario == null)
                return NotFound("Esse usuário e/ou senha não existem ou inválidos");


            var token = TokenService.GenerateToken(usuario);
            usuario.senha = "";
            return new
            {
                usuario = usuario,
                token = token
            };
        }
    }
}
