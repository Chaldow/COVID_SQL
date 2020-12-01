using COVID_19.Models;
using COVID_19.Repositories;
using COVID_19.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COVID_19.Services
{
    public class PacienteService : IPacienteService
    {
        private IPacienteRepository _repository;

        public PacienteService(IPacienteRepository repository) {
            _repository = repository;


        }
        public void atualizar(int id, Paciente paciente) 
        {
            var resultadoPaciente = this.buscaPorId(id); 
            if(resultadoPaciente == null ) 
            {
                throw new ArgumentException("Paciente não existe"); 
            }
            paciente.id = id;
            _repository.AtualizarPaciente(paciente);
       
        }
        public IList<Paciente> buscaTodosPacientes()
        {
            return _repository.ListarTodosPacientes();
        }

        public Paciente buscaPorId(int id)
        {
            return _repository.BuscarPacientePorId(id);
        }
        public IList<Paciente> buscaPorCPF(string cpf) 
        {
            return _repository.BuscarPacienteCPF(cpf);
        }
        
        public IList<Paciente> buscaPorCidade(string cidade)
        {
            return _repository.BuscarPacienteCidade (cidade);
        }

        public int inserir(Paciente paciente)
        {
            var validator = new PacienteValidator();
            var validRes = validator.Validate(paciente);
            if (validRes.IsValid)
                return _repository.InserirPaciente(paciente);
            else
                throw new Exception(validRes.Errors.FirstOrDefault().ToString());
        }

        public void remover(int id)
        {
            var resultadoPaciente = buscaPorId(id);
            if(resultadoPaciente == null)
                {
                throw new ArgumentException("Paciente não existe");
            }
            _repository.RemoverPaciente(resultadoPaciente);
        }

        public void atualizar(int id)
        {
            throw new NotImplementedException();
        }
    }
}
