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
        public void InserirPaciente(Paciente paciente);
    }
}
