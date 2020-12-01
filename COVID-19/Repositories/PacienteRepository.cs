<<<<<<< HEAD
﻿using COVID_19.Context;
using COVID_19.Models;
using COVID_19.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COVID_19.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        private COVID_Context context;

        public PacienteRepository(COVID_Context _context) {
            context = _context;    
        }

        //private IList<Paciente> listaPaciente = new List<Paciente>();

        public void AtualizarPaciente(Paciente paciente)
        {
            context.Entry(paciente).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
        public int InserirPaciente(Paciente paciente)
        {
            context.pacientes.Add(paciente);
            context.SaveChanges();
            return paciente.id;
        }

        public Paciente BuscarPacientePorId(int pid)
        {
            return context.pacientes.Where(c => c.id == pid).FirstOrDefault();
        }
        public IList<Paciente> BuscarPacienteCidade(string cidade)
        {
            return (IList<Paciente>)context.pacientes.Where(p => p.cidade == cidade);
        }
        public IList<Paciente> BuscarPacienteCPF(string cpf)
        {
            return (IList<Paciente>)context.pacientes.Where(c => c.cpf == cpf).FirstOrDefault();
        }


        public IList<Paciente> ListarTodosPacientes()
        {
            return (IList<Paciente>) context.pacientes;
        }
        public void RemoverPaciente(Paciente paciente)
        {
            context.pacientes.Remove(paciente);
            context.SaveChanges();
        }

    }
}
=======
﻿using COVID_19.Context;
using COVID_19.Models;
using COVID_19.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COVID_19.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        private COVID_Context context;

        public PacienteRepository() {
            context = new COVID_Context();    
        }

        private IList<Paciente> listaPaciente = new List<Paciente>();
       
        public Paciente BuscarPacientePorId(int pid)
        {
            return context.PACIENTE.Where(c => c.id == pid).FirstOrDefault();
        }
        public IList<Paciente> BuscarPacienteCidade(string cidade)
        {
            return (IList<Paciente>)context.PACIENTE.Where(p => p.cidade == cidade);
        }
        public Paciente BuscarPacienteCPF(string cpf)
        {
            return context.PACIENTE.Where(c => c.cpf == cpf).FirstOrDefault();
        }

        public void InserirPaciente(Paciente paciente)
        {
            var validator = new PacienteValidator();
            var validRes = validator.Validate(paciente);
            if (validRes.IsValid)
                context.PACIENTE.Add(paciente);
            else
                throw new Exception(validRes.Errors.FirstOrDefault().ToString());
        }
        public IList<Paciente> ListarTodosPacientes()
        {
            return (IList<Paciente>) context.PACIENTE;
        }
    }
}
>>>>>>> 558924129279b0eac27cda33037ed099f7c5527c
