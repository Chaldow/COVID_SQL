using COVID_19.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COVID_19.Repositories
{
    public interface IPacienteRepository
    {
        public IList<Paciente> ListarTodosPacientes();
        public Paciente BuscarPacientePorId(int id);
        public IList<Paciente> BuscarPacienteCidade(string cidade);
        public IList<Paciente> BuscarPacienteCPF(string cpf);
        public int InserirPaciente(Paciente paciente);
        public void RemoverPaciente(Paciente paciente);
        public void AtualizarPaciente(Paciente paciente);


    }
}
