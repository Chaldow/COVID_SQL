<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using COVID_19.Models;
using COVID_19.Repositories;
using COVID_19.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace COVID_19.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "administrador")]
    public class PacienteController : ControllerBase
    {
        private readonly IPacienteService _service;
        public PacienteController(IPacienteService services) 
        {
            _service = services;
        }
        [HttpGet]
        public async Task<IActionResult> Get() 
        {
            return Ok("Listagem de todos os pacientes");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var pacienteTeste = _service.buscaPorId(id);
            if (pacienteTeste == null)
            {
                return NotFound();
            }

            return Ok(pacienteTeste);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Paciente paciente)
        {
            _service.inserir(paciente);
         return Ok("Paciente criado com sucesso");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Paciente paciente) {
            _service.atualizar(id);
            return Ok("Paciente atualizado com sucesso"); 
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id) {
            _service.remover(id);
            return Ok("Paciente removido com sucesso!"); 
        }


    }
}
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using COVID_19.Models;
using COVID_19.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace COVID_19.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "administrador")]
    public class PacienteController : ControllerBase
    {
        private PacienteRepository _repository;
        public PacienteController() 
        {
            _repository = new PacienteRepository();
        }
        [HttpGet]
        public async Task<IActionResult> Get() 
        {
            return Ok("Listagem de todos os pacientes");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var pacienteTeste = _repository.BuscarPacientePorId(id);
            if (pacienteTeste == null)
            {
                return NotFound();
            }

            return Ok(pacienteTeste);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Paciente paciente)
        {
         _repository.InserirPaciente(paciente);
         return Ok("Paciente criado com sucesso");
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, Paciente paciente) { return Ok("Paciente atualizado com sucesso"); }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id) { return Ok("Paciente removido com sucesso!"); }


    }
}
>>>>>>> 558924129279b0eac27cda33037ed099f7c5527c
